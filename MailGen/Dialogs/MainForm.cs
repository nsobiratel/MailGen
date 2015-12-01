namespace MailGen.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    using BrightIdeasSoftware;

    using Classes.Auth;

    using Classes.Logging.Loggers;
    using Classes.Logging.Realizations;

    using Classes;

    using Properties;

    using Microsoft.Exchange.WebServices.Data;

    using MsgReader.Outlook;

    internal sealed partial class MainForm : Form
    {
        private static ExchangeService _service;

        public MainForm()
        {
            this.InitializeComponent();

            Logger.AddAlgorithm(new ComponentLogWriteAlgorithm(str => this.lbLog.Items.Add(str)));
        }

        private static bool TryGetFolder(string folderConfParam, out Folder folder)
        {
            try
            {
                FolderView view = new FolderView(int.MaxValue)
                {
                    PropertySet = new PropertySet(BasePropertySet.IdOnly) { FolderSchema.DisplayName },
                    Traversal = FolderTraversal.Deep
                };

                string folderName = Config.GetParam(folderConfParam);

                SearchFilter filter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName);

                FindFoldersResults res = _service.FindFolders(WellKnownFolderName.Root, filter, view);

                if (res.TotalCount > 1)
                {
                    Logger.Error(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            LocalizibleStrings.FolderNotFound,
                            folderName,
                            folderConfParam));
                }
                else if (res.TotalCount < 1)
                {
                    Logger.Error(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            LocalizibleStrings.FolderNotFound,
                            folderName,
                            folderConfParam));
                    folder = null;
                    return false;
                }

                folder = res.Folders[0];
                return true;
            }
            catch (Exception exc)
            {
                Logger.Error(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        LocalizibleStrings.CannotGetTemplateFolder,
                        folderConfParam),
                    exc);
                folder = null;
                return false;
            }
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            this.lbLog.Items.Clear();
        }

        private void ProcessConnectionItem(object sender)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                if (item == null)
                {
                    Logger.Error(LocalizibleStrings.CannotProcessMenuItem);
                    return;
                }

                ExchangeVersion version;
                if (!Enum.TryParse(item.Tag as string, true, out version))
                {
                    Logger.Error(LocalizibleStrings.UnrecognizedEwsVersion + item.Tag);
                    return;
                }

                ConnectionParams param = new ConnectionParams(
                    version,
                    Config.GetParam(Config.EwsUri),
                    new UserData(
                        Config.GetParam(Config.User),
                        Config.GetParam(Config.UserEmail),
                        Config.GetParam(Config.Password),
                        Config.GetParam(Config.Domain)),
                    true);

                if (!Service.TryConnectToService(this, param, out _service))
                {
                    return;
                }

                this.SuspendLayout();
                this.generateToolStripMenuItem.Enabled = true;
                this.saveSettingsToolStripMenuItem.Enabled = true;
                // Bug VS
                SetEnabled(this);
                this.clTargetContacts.tsbtnRefresh.PerformClick();
                this.ResumeLayout(true);
            }
            catch (Exception exc)
            {
                Logger.Error(LocalizibleStrings.CannotConnectToEws, exc);
            }
        }

        private void GenerateToolStripMenuItemClick(object sender, EventArgs e)
        {
            BtnGenerateAllClick(null, null);
        }

        private static void SetEnabled(Control ctl)
        {
            ctl.Enabled = true;

            if (!ctl.HasChildren)
                return;

            foreach (Control child in ctl.Controls)
            {
                SetEnabled(child);
            }
        }

        private void SaveSettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            Config.SaveConfig();
            IEnumerable<StoredContact> contacts =
                this.clTargetContacts.dgObjects.Objects.Cast<StoredContact>();
            foreach (StoredContact contact in contacts)
            {
                contact.Save();
            }
        }

        private void RussianToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeCulture(LocalizationHelper.RuStr);
        }

        private static void ChangeCulture(string culture)
        {
            Config.SetParam(Config.Lang, culture);

            DialogResult res = MessageBox.Show(
                LocalizibleStrings.MessageNeedRestart,
                LocalizibleStrings.Warning,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes)
            {
                Application.Restart();
            }

            /*CultureInfo info = LocalizationHelper.TryGetCulture(culture);

            Application.CurrentCulture = info;
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

            resources.ApplyResources(this, "$this");

            ApplyResourcesHierarhically(resources, this.Controls);*/
        }

        /*private static void ApplyResourcesHierarhically(
            ComponentResourceManager resources, IEnumerable controls)
        {
            foreach (Control c in controls)
            {
                resources.ApplyResources(c, c.Name);
                ApplyResourcesHierarhically(resources, c.Controls);
            }
        }*/

        private void EnglishToolStripMenuItemClick(object sender, EventArgs e)
        {
            ChangeCulture(LocalizationHelper.EnStr);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.panel1.Enabled = false;
            this.generateToolStripMenuItem.Enabled = false;
            this.saveSettingsToolStripMenuItem.Enabled = false;

            this.splitContainer4.SplitterWidth = 10;
            this.splitContainer1.SplitterWidth = 10;
            this.RearrangeCountControls();

            ToolStripButton tsbtnMove =
                new ToolStripButton(LocalizibleStrings.BtnAddSelectedToMailList)
                {
                    DisplayStyle = ToolStripItemDisplayStyle.Image,
                    Image = LocalizibleStrings.ArrowRight
                };

            tsbtnMove.Click += (o, args) =>
            {
                IEnumerable<StoredContact> storedContacts =
                    this.clTargetContacts.dgObjects.Objects.Cast<StoredContact>().ToList();

                foreach (Contact obj in
                    from Contact obj in this.clEwsContacts.dgObjects.SelectedObjects
                    let existed = storedContacts.FirstOrDefault(s => s.UniqId == obj.Id.UniqueId)
                    where existed == null
                    select obj)
                {
                    this.clTargetContacts.dgObjects.AddObject(new StoredContact(obj));
                }
            };

            this.clEwsContacts._barTools.Items.Insert(2, tsbtnMove);

            string mailTemplateFolder;
            string eventTemplateFolder;

            switch (Thread.CurrentThread.CurrentUICulture.LCID)
            {
                case LocalizationHelper.EnInt:
                    this.englishToolStripMenuItem.Checked = true;
                    this.russianToolStripMenuItem.Checked = false;
                    mailTemplateFolder = Config.EmailTemplateFolderEn;
                    eventTemplateFolder = Config.EventTemplateFolderEn;
                    break;
                case LocalizationHelper.RuInt:
                    this.russianToolStripMenuItem.Checked = true;
                    this.englishToolStripMenuItem.Checked = false;
                    mailTemplateFolder = Config.EmailTemplateFolderRu;
                    eventTemplateFolder = Config.EventTemplateFolderRu;
                    break;
                default:
                    this.englishToolStripMenuItem.Checked = true;
                    this.russianToolStripMenuItem.Checked = false;
                    mailTemplateFolder = Config.EmailTemplateFolderEn;
                    eventTemplateFolder = Config.EventTemplateFolderEn;
                    break;
            }

            this.SetEwsContactsColumns();
            this.SetMailTemplatesColumns();
            this.SetEventTemplatesColumns();
            this.SetTargetContactsColumns();

            this.clEwsContacts.tsbtnFilteredProperties.Visible = false;
            this.clEwsContacts.tsbtnCreate.Visible = false;
            this.clEwsContacts.tsbtnEdit.Visible = false;
            this.clEwsContacts.tsbtnDelete.Visible = false;
            this.clEwsContacts.tsbtnFilterSettings.Visible = false;
            this.clEwsContacts.tsbtnFilteredProperties.Visible = false;

            this.clEwsContacts.tsbtnRefresh.Text = LocalizibleStrings.BtnRefresh;
            this.clEwsContacts.tsbtnClearFilter.Text = LocalizibleStrings.BtnClear;
            this.clEwsContacts.tsbtnSearch.Text = LocalizibleStrings.BtnSearch;
            this.clEwsContacts.tslbSearch.Text = LocalizibleStrings.LbSearch;
            this.clEwsContacts.tslbCount.Text = LocalizibleStrings.LbCount;

            this.clEwsContacts.tsbtnRefresh.Click += (s, args) =>
            {
                try
                {
                    Folder contactsFolder;
                    if (!TryGetFolder(Config.ContactFolder, out contactsFolder))
                    {
                        Logger.Message(LocalizibleStrings.TryLoadFromDefault);
                        contactsFolder = ContactsFolder.Bind(_service, WellKnownFolderName.Contacts);
                    }

                    SearchFilter sf = new SearchFilter.IsEqualTo(ItemSchema.ItemClass, @"IPM.Contact");

                    FindItemsResults<Item> items =
                        contactsFolder.FindItems(sf, new ItemView(int.MaxValue));
                    this.clEwsContacts.dgObjects.SetObjects(items.ToList());
                }
                catch (Exception exc)
                {
                    Logger.Error(LocalizibleStrings.CannotGetContactList, exc);
                }
            };

            this.clMailTemplates.tsbtnFilteredProperties.Visible = false;
            this.clMailTemplates.tsbtnCreate.Visible = false;
            this.clMailTemplates.tsbtnEdit.Visible = false;
            this.clMailTemplates.tsbtnDelete.Visible = false;
            this.clMailTemplates.tsbtnFilterSettings.Visible = false;
            this.clMailTemplates.tsbtnFilteredProperties.Visible = false;

            this.clMailTemplates.tsbtnRefresh.Text = LocalizibleStrings.BtnRefresh;
            this.clMailTemplates.tsbtnClearFilter.Text = LocalizibleStrings.BtnClear;
            this.clMailTemplates.tsbtnSearch.Text = LocalizibleStrings.BtnSearch;
            this.clMailTemplates.tslbSearch.Text = LocalizibleStrings.LbSearch;
            this.clMailTemplates.tslbCount.Text = LocalizibleStrings.LbCount;

            this.clMailTemplates.tsbtnRefresh.Click += (s, args) =>
            {
                try
                {
                    /*Folder templatesFolder;
                    if (!TryGetFolder(mailTemplateFolder, out templatesFolder))
                        return;

                    FindItemsResults<Item> items =
                        templatesFolder.FindItems(new ItemView(int.MaxValue));*/

                    IEnumerable<Storage.Message> items = 
                        Directory.GetFiles(Config.GetParam(mailTemplateFolder)).Select(t => new Storage.Message(t));
                    
                    this.clMailTemplates.dgObjects.SetObjects(items.ToList());
                }
                catch (Exception exc)
                {
                    Logger.Error(LocalizibleStrings.CannotGetMailTemplateList, exc);
                }
            };

            this.clEventTemplates.tsbtnCreate.Visible = false;
            this.clEventTemplates.tsbtnEdit.Visible = false;
            this.clEventTemplates.tsbtnDelete.Visible = false;
            this.clEventTemplates.tsbtnFilterSettings.Visible = false;
            this.clEventTemplates.tsbtnFilteredProperties.Visible = false;

            this.clEventTemplates.tsbtnRefresh.Text = LocalizibleStrings.BtnRefresh;
            this.clEventTemplates.tsbtnClearFilter.Text = LocalizibleStrings.BtnClear;
            this.clEventTemplates.tsbtnSearch.Text = LocalizibleStrings.BtnSearch;
            this.clEventTemplates.tslbSearch.Text = LocalizibleStrings.LbSearch;
            this.clEventTemplates.tslbCount.Text = LocalizibleStrings.LbCount;

            this.clEventTemplates.tsbtnRefresh.Click += (s, args) =>
            {
                try
                {
                    /*Folder templatesFolder;
                    if (!TryGetFolder(eventTemplateFolder, out templatesFolder))
                        return;

                    FindItemsResults<Item> items =
                        templatesFolder.FindItems(new ItemView(int.MaxValue));*/

                    List<Storage.Message> tasks = 
                        Directory.GetFiles(Config.GetParam(eventTemplateFolder))
                            .Select(t => new Storage.Message(t))
                            .ToList();

                    this.clEventTemplates.dgObjects.SetObjects(tasks);
                }
                catch (Exception exc)
                {
                    Logger.Error(LocalizibleStrings.CannotGetEventTemplateList, exc);
                }
            };

            this.clTargetContacts.tsbtnCreate.Text = LocalizibleStrings.BtnCreate;
            this.clTargetContacts.tsbtnDelete.Text = LocalizibleStrings.BtnDelete;
            this.clTargetContacts.tsbtnRefresh.Text = LocalizibleStrings.BtnRefresh;
            this.clTargetContacts.tsbtnClearFilter.Text = LocalizibleStrings.BtnClear;
            this.clTargetContacts.tsbtnSearch.Text = LocalizibleStrings.BtnSearch;
            this.clTargetContacts.tslbSearch.Text = LocalizibleStrings.LbSearch;
            this.clTargetContacts.tslbCount.Text = LocalizibleStrings.LbCount;

            this.clTargetContacts.tsbtnCreate.Visible = true;
            this.clTargetContacts.tsbtnEdit.Visible = false;
            this.clTargetContacts.tsbtnDelete.Visible = true;
            this.clTargetContacts.tsbtnFilterSettings.Visible = false;
            this.clTargetContacts.tsbtnFilteredProperties.Visible = false;

            this.clTargetContacts.dgObjects.TriStateCheckBoxes = false;
            this.clTargetContacts.dgObjects.RenderNonEditableCheckboxesAsDisabled = false;
            this.clTargetContacts.dgObjects.UseSubItemCheckBoxes = true;

            ToolStripButton tsbtnSave =
                new ToolStripButton(LocalizibleStrings.BtnSaveAll)
                {
                    DisplayStyle = ToolStripItemDisplayStyle.Image,
                    Image = LocalizibleStrings.Save
                };

            tsbtnSave.Click +=
                (o, args) =>
                {
                    IEnumerable<StoredContact> contacts =
                        this.clTargetContacts.dgObjects.Objects.Cast<StoredContact>();
                    foreach (StoredContact contact in contacts)
                    {
                        contact.Save();
                    }
                };

            this.clTargetContacts._barTools.Items.Insert(1, tsbtnSave);

            this.clTargetContacts.tsbtnRefresh.Click += (s, args) =>
            {
                try
                {
                    this.clTargetContacts.dgObjects.SetObjects(StoredContact.GetAll());
                }
                catch (Exception exc)
                {
                    Logger.Error(LocalizibleStrings.CannotGetStoredContacts, exc);
                }
            };

            this.clTargetContacts.tsbtnCreate.Click +=
                (o, args) => this.clTargetContacts.dgObjects.AddObject(new StoredContact());

            this.clTargetContacts.tsbtnDelete.Click += (o, args) =>
            {
                DialogResult res = MessageBox.Show(
                    LocalizibleStrings.DeleteConfirmation,
                    LocalizibleStrings.Warning,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (res == DialogResult.No)
                    return;

                foreach (StoredContact cont in this.clTargetContacts.dgObjects.SelectedObjects)
                {
                    try
                    {
                        this.clTargetContacts.dgObjects.RemoveObject(cont);
                        cont.Delete();
                    }
                    catch (Exception exc)
                    {
                        Logger.Error(LocalizibleStrings.CannotDeleteContact + cont.FileName, exc);
                    }
                }
            };
        }

        private void RearrangeCountControls()
        {
            this.numMailsCount.Width = 50;
            this.numEventsCount.Width = 50;

            const AnchorStyles anchors = AnchorStyles.Bottom & AnchorStyles.Left;

            this.numEventsCount.Anchor = anchors;
            this.numMailsCount.Anchor = anchors;
            this.lbMailsCount.Anchor = anchors;
            this.lbEventsCount.Anchor = anchors;

            this.lbMailsCount.Location = new Point(10, 10);

            this.numMailsCount.Location =
                new Point(
                    this.lbMailsCount.Location.X + this.lbMailsCount.Width + 5, 8);
            this.lbEventsCount.Location =
                new Point(
                    this.numMailsCount.Location.X + this.numMailsCount.Width + 5, 10);
            this.numEventsCount.Location =
                new Point(
                    this.lbEventsCount.Location.X + this.lbEventsCount.Width + 5, 8);
        }

        private void SetTargetContactsColumns()
        {
            this.clTargetContacts.dgObjects.Dock = DockStyle.Fill;
            List<OlvColumn> columns = new List<OlvColumn>();

            OlvColumn column = new OlvColumn
            {
                AspectName = @"Email",
                Text = @"email",
                FillsFreeSpace = false,
                Groupable = false,
                Hideable = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = true,
                Width = 200,
                DisplayIndex = 0
            };
            columns.Add(column);
            this.clTargetContacts.dgObjects.PrimarySortColumn = column;

            column = new OlvColumn
            {
                AspectName = @"CanBeSender",
                Text = LocalizibleStrings.ColumnCanSend,
                FillsFreeSpace = false,
                Groupable = true,
                Hideable = true,
                CheckBoxes = true,
                DataType = typeof(bool),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Center,
                TriStateCheckBoxes = false,
                Width = 100,
                IsEditable = true
            };
            columns.Add(column);

            column = new OlvColumn
            {
                AspectName = @"CanBeRecipient",
                Text = LocalizibleStrings.ColumnCanReceive,
                FillsFreeSpace = false,
                Groupable = true,
                Hideable = true,
                CheckBoxes = true,
                DataType = typeof(bool),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Center,
                Width = 100,
                TriStateCheckBoxes = false,
                IsEditable = true,
                AspectPutter = (obj, boolValue) =>
                {
                    StoredContact contact = obj as StoredContact;
                    if (contact == null)
                        return;
                    if (!contact.IsEwsContact)
                        return;
                    contact.CanBeRecipient = (bool)boolValue;
                }
            };
            columns.Add(column);

            this.clTargetContacts.dgObjects.AllColumns.AddRange(columns);
            this.clTargetContacts.dgObjects.RebuildColumns();
            this.clTargetContacts.dgObjects.Sorting = SortOrder.Ascending;
            this.clTargetContacts.dgObjects.Sort();
        }

        private void SetEventTemplatesColumns()
        {
            this.clEventTemplates.dgObjects.Dock = DockStyle.Fill;
            OlvColumn column = new OlvColumn
            {
                AspectName = @"Subject",
                Text = LocalizibleStrings.ColumnSubject,
                FillsFreeSpace = false,
                Groupable = false,
                Hideable = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = true,
                Width = 200,
                DisplayIndex = 0/*,
                AspectGetter = o =>
                {
                    CalendarEvent ev = o as CalendarEvent;
                    return ev == null ? null : ev.Details.Subject;
                }*/
            };
            this.clEventTemplates.dgObjects.PrimarySortColumn = column;

            this.clEventTemplates.dgObjects.AllColumns.Add(column);
            this.clEventTemplates.dgObjects.RebuildColumns();
            this.clEventTemplates.dgObjects.Sorting = SortOrder.Ascending;
            this.clEventTemplates.dgObjects.Sort();
        }

        private void SetMailTemplatesColumns()
        {
            this.clMailTemplates.dgObjects.Dock = DockStyle.Fill;
            OlvColumn column = new OlvColumn
            {
                AspectName = @"Subject",
                Text = LocalizibleStrings.ColumnSubject,
                FillsFreeSpace = false,
                Groupable = false,
                Hideable = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = true,
                Width = 200,
                DisplayIndex = 0
            };
            this.clMailTemplates.dgObjects.PrimarySortColumn = column;

            /*OlvColumn column = new OlvColumn
            {
                AspectName = @"Subject",
                Text = LocalizibleStrings.ColumnSubject,
                FillsFreeSpace = false,
                Groupable = false,
                Hideable = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = true,
                Width = 200,
                DisplayIndex = 0
            };
            this.clMailTemplates.dgObjects.PrimarySortColumn = column;*/

            this.clMailTemplates.dgObjects.AllColumns.Add(column);
            this.clMailTemplates.dgObjects.RebuildColumns();
            this.clMailTemplates.dgObjects.Sorting = SortOrder.Ascending;
            this.clMailTemplates.dgObjects.Sort();
        }

        private void SetEwsContactsColumns()
        {
            this.clEwsContacts.dgObjects.Dock = DockStyle.Fill;
            List<OlvColumn> columns = new List<OlvColumn>();

            OlvColumn column = new OlvColumn
            {
                AspectName = @"DisplayName",
                Text = LocalizibleStrings.ColumnName,
                FillsFreeSpace = false,
                Groupable = true,
                Hideable = false,
                CheckBoxes = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Center,
                Width = 200,
                DisplayIndex = 0,
                IsEditable = false
            };
            columns.Add(column);

            this.clEwsContacts.dgObjects.PrimarySortColumn = column;

            column = new OlvColumn
            {
                Text = @"email",
                FillsFreeSpace = false,
                Groupable = false,
                Hideable = false,
                DataType = typeof(string),
                HeaderTextAlign = HorizontalAlignment.Center,
                TextAlign = HorizontalAlignment.Left,
                IsEditable = false,
                Width = 200,
                DisplayIndex = 1,
                AspectGetter = o =>
                {
                    Contact contact = o as Contact;
                    if (contact == null)
                        return null;
                    EmailAddress adress;
                    return contact.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress1, out adress)
                        ? adress.Address : null;
                }
            };
            columns.Add(column);

            this.clEwsContacts.dgObjects.AllColumns.AddRange(columns);
            this.clEwsContacts.dgObjects.RebuildColumns();
            this.clEwsContacts.dgObjects.Sorting = SortOrder.Ascending;
            this.clEwsContacts.dgObjects.Sort();
        }

        private void V2010ToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ProcessConnectionItem(sender);
        }

        private void V2010Sp1ToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ProcessConnectionItem(sender);
        }

        private void V2010Sp2ToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ProcessConnectionItem(sender);
        }

        private void V2013ToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ProcessConnectionItem(sender);
        }

        private void V2013SpToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ProcessConnectionItem(sender);
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            Process.Start(Config.GetParam(Config.LogFileName));
        }

        private void SplitContainer1SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void BtnGenerateAllClick(object sender, EventArgs e)
        {
            BtnGenMailClick(null, null);
            BtnGenerateEventsClick(null, null);
        }

        private void BtnGenMailClick(object sender, EventArgs e)
        {
            IList<StoredContact> contacts =
                this.clTargetContacts.dgObjects.Objects
                    .Cast<StoredContact>()
                    .ToList();

            IList<StoredContact> senders =
                contacts.Where(c => c.CanBeSender).ToList();

            if (senders.Count <= 0)
            {
                GenericLogger<MainForm>.Error(LocalizibleStrings.SendersCount);
                return;
            }

            int sendersMax = senders.Count - 1;

            IList<StoredContact> recipients =
                contacts.Where(c => c.CanBeRecipient).ToList();

            if (recipients.Count <= 0)
            {
                GenericLogger<MainForm>.Error(LocalizibleStrings.RecipientsCount);
                return;
            }

            Random rnd = new Random();
            int recipientsMax = recipients.Count - 1;

            int sendedCount = 1;

            // если хотят больше, чем есть шаблонов
            if (this.numMailsCount.Value >= this.clMailTemplates.dgObjects.ItemCount)
            {
                // генерируем по всем + дополнительные круги, сколько сможем
                while (sendedCount <= this.numMailsCount.Value)
                {
                    foreach (Storage.Message msg in this.clMailTemplates.dgObjects.Objects)
                    {
                        EmailMessage newMsg = new EmailMessage(_service);

                        // меняем параметры письма
                        newMsg. = senders[rnd.Next(sendersMax)].Email;

                        if (rnd.Next(1) == 0)
                        {
                            msg.ToRecipients.Add(recipients[rnd.Next(recipientsMax)].Email);
                        }
                        else
                        {
                            msg.ToRecipients.Add(recipients[rnd.Next(recipientsMax)].Email);
                            msg.ToRecipients.Add(recipients[rnd.Next(recipientsMax)].Email);
                        }

                        if (rnd.Next(1) == 1)
                        {
                            msg.Forward(new MessageBody("test body prefix for forward message"));
                        }

                        if (rnd.Next(1) == 1)
                        {
                            msg.Reply(new MessageBody("test body prefix for reply message"),
                                Convert.ToBoolean(rnd.Next(1)));
                        }

                        // отправляем через ews
                        msg.Send();
                        sendedCount++;

                        msg.From = null;
                        msg.ToRecipients.Clear();

                        // если уже сгенерировали сколько надо
                        if (sendedCount == this.numMailsCount.Value)
                            break;
                    }
                }
            }
            else
            {
                int templatesCount = this.clMailTemplates.dgObjects.ItemCount - 1;
                while (sendedCount <= this.numMailsCount.Value)
                {
                    int rndIndex = rnd.Next(0, templatesCount);
                    EmailMessage msg = this.clMailTemplates.dgObjects.Objects[rndIndex] as EmailMessage;
                    if (msg == null)
                        continue;

                    // меняем параметры письма
                    // ....
                    //

                    // отправляем через ews
                    msg.Send();
                    sendedCount++;
                }
            }
        }

        private void BtnGenerateEventsClick(object sender, EventArgs e)
        {

        }
    }
}
