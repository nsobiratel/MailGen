using System;
using System.Collections.Generic;
using System.Linq;

namespace MailGen.Classes
{
    using System.Runtime.CompilerServices;
    using Logging.Loggers;
    using Microsoft.Exchange.WebServices.Data;
    using MsgReader.Outlook;
    using Properties;

    internal sealed class Generator
    {
        private readonly ExchangeService service;
        private static readonly Random Rnd = new Random();
        private readonly IList<StoredContact> senders;
        private readonly IList<StoredContact> recipients;
        private readonly int countPerRecipient;
        private readonly IList<Storage.Message> templates;
        private readonly Action callback;
        private readonly int recipientsMax;

        public Generator(
            ref ExchangeService service,
            ref IList<StoredContact> contacts,
            ref IList<Storage.Message> templates,
            int mailsCountPerRecipient,
            Action progressCallback)
        {
            this.service = service;
            this.countPerRecipient = mailsCountPerRecipient;

            this.senders = contacts.Where(c => c.CanBeSender).ToList();

            this.recipients =
                contacts.Where(c => c.CanBeRecipient).ToList();

            this.recipientsMax = this.recipients.Count;

            this.templates = templates;
            this.callback = progressCallback;
        }

        public void GenEmails()
        {
            try
            {
                if (this.senders.Count <= 0)
                {
                    GenericLogger<Generator>.Error(LocalizibleStrings.SendersCount);
                    return;
                }

                if (this.recipients.Count <= 0)
                {
                    GenericLogger<Generator>.Error(LocalizibleStrings.RecipientsCount);
                    return;
                }

                ParallelQuery<GenResult> results = this.recipients.AsParallel().SelectMany(recipient =>
                    {
                        List<GenResult> genMsgs =
                            new List<GenResult>(this.countPerRecipient);

                        int genCount = 0;

                        while (genCount < this.countPerRecipient)
                        {
                            foreach (StoredContact sender in this.senders)
                            {
                                foreach (Storage.Message template in this.templates)
                                {
                                    GenResult newMsg =
                                        this.EmailMessageFromMessage(
                                            sender,
                                            recipient,
                                            template);

                                    if (newMsg.msg == null)
                                        return genMsgs;

                                    genMsgs.Add(newMsg);
                                    genCount++;

                                    if (newMsg.reply != null)
                                        genCount++;

                                    if (newMsg.response != null)
                                        genCount++;

                                    GenericLogger<Generator>.Message(
                                        LocalizibleStrings.MsgCreatedOf,
                                        genCount, this.countPerRecipient);

                                    this.callback.BeginInvoke(null, null);

                                    if (genCount == this.countPerRecipient)
                                        return genMsgs;
                                }

                                if (genCount == this.countPerRecipient)
                                    return genMsgs;
                            }
                        }

                        return genMsgs;
                    });

                GenericLogger<Generator>.Message(LocalizibleStrings.MsgSendingStarted);
                results.ForAll(res =>
                {
                    try
                    {
                        res.msg.Send();
                        if (res.response != null)
                            res.response.Send();
                        if (res.reply != null)
                            res.reply.Send();
                    }
                    catch (Exception exc)
                    {
                        GenericLogger<Generator>.Message("Sending error " + exc);
                    }
                });
                GenericLogger<Generator>.Message(LocalizibleStrings.MsgSendingFinished);
            }
            catch (Exception exc)
            {
                GenericLogger<Generator>.Error(
                    LocalizibleStrings.ErrorGenMailMsg, exc);
            }
        }

        #region
        /*
        private GenResult EmailMessageFromMessage(
            ref IList<StoredContact> senders,
            int sendersMax,
            ref IList<StoredContact> recipients,
            int recipientsMax,
            ref Random _rnd,
            ref Storage.Message msg)
        {
            GenResult res = new GenResult();
            try
            {
                EmailAddress em =
                    Contact.Bind(_service, new ItemId(senders[_rnd.Next(sendersMax)].UniqId))
                        .EmailAddresses[EmailAddressKey.EmailAddress1];

                EmailMessage newMsg = new EmailMessage(_service)
                {
                    From = em,
                    Sender = em,
                    Body = new MessageBody(msg.BodyHtml),
                    Subject = msg.Subject
                };

                newMsg.Save(WellKnownFolderName.Drafts);

                foreach (object obj in msg.Attachments)
                {
                    Storage.Attachment attach = obj as Storage.Attachment;
                    if (attach == null)
                        continue;
                    newMsg.Attachments.AddFileAttachment(attach.FileName, attach.Data);
                }

                string email;

                // выбираем, какие поля заполнять:
                //  - обычный список получателей
                //  - теневую копию
                //  - и то и другое
                if (_rnd.Next(2) == 0)
                {
                    switch (_rnd.Next(3))
                    {
                        case 0:
                            // заполняем обычный список получателей
                            email = recipients[_rnd.Next(recipientsMax)].Email;
                            //AddDelegateForInbox(email);
                            newMsg.CcRecipients.Add(email);
                            if (_rnd.Next(2) == 0)
                            {
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                newMsg.CcRecipients.Add(email);
                            }
                            break;
                        case 1:
                            // заполняем теневую копию
                            email = recipients[_rnd.Next(recipientsMax)].Email;
                            //AddDelegateForInbox(email);
                            newMsg.BccRecipients.Add(email);
                            if (_rnd.Next(2) == 0)
                            {
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                newMsg.BccRecipients.Add(email);
                            }
                            break;
                        default:
                            // заполняем обычный список получателей
                            email = recipients[_rnd.Next(recipientsMax)].Email;
                            //AddDelegateForInbox(email);
                            newMsg.CcRecipients.Add(email);
                            if (_rnd.Next(2) == 0)
                            {
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                newMsg.CcRecipients.Add(email);
                            }
                            // заполняем теневую копию
                            email = recipients[_rnd.Next(recipientsMax)].Email;
                            //AddDelegateForInbox(email);
                            newMsg.BccRecipients.Add(email);
                            if (_rnd.Next(2) == 0)
                            {
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                newMsg.BccRecipients.Add(email);
                            }
                            break;
                    }
                }
                email = recipients[_rnd.Next(recipientsMax)].Email;
                //AddDelegateForInbox(email);
                newMsg.ToRecipients.Add(email);

                if (_rnd.Next(2) == 0)
                {
                    email = recipients[_rnd.Next(recipientsMax)].Email;
                    //AddDelegateForInbox(email);
                    newMsg.ToRecipients.Add(email);
                }

                res.msg = newMsg;

                if (_rnd.Next(2) == 0)
                {
                    newMsg.Update(ConflictResolutionMode.AlwaysOverwrite);
                    ResponseMessage respMsg = newMsg.CreateForward();
                    respMsg.BodyPrefix = @"test body prefix for forward message";
                    respMsg.Save(WellKnownFolderName.Drafts);

                    respMsg.ToRecipients.Add(recipients[_rnd.Next(recipientsMax)].Email);
                    if (_rnd.Next(2) == 0)
                        respMsg.ToRecipients.Add(recipients[_rnd.Next(recipientsMax)].Email);

                    res.response = respMsg;

                    // выбираем, какие поля заполнять:
                    //  - обычный список получателей
                    //  - теневую копию
                    //  - и то и другое
                    if (_rnd.Next(2) == 0)
                    {
                        switch (_rnd.Next(3))
                        {
                            case 0:
                                // заполняем обычный список получателей
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                respMsg.CcRecipients.Add(email);
                                if (_rnd.Next(2) == 0)
                                {
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    respMsg.CcRecipients.Add(email);
                                }
                                break;
                            case 1:
                                // заполняем теневую копию
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                respMsg.BccRecipients.Add(email);
                                if (_rnd.Next(2) == 0)
                                {
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    respMsg.BccRecipients.Add(email);
                                }
                                break;
                            default:
                                // заполняем обычный список получателей
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                respMsg.CcRecipients.Add(email);
                                if (_rnd.Next(2) == 0)
                                {
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    respMsg.CcRecipients.Add(email);
                                }
                                // заполняем теневую копию
                                email = recipients[_rnd.Next(recipientsMax)].Email;
                                //AddDelegateForInbox(email);
                                respMsg.BccRecipients.Add(email);
                                if (_rnd.Next(2) == 0)
                                {
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    respMsg.BccRecipients.Add(email);
                                }
                                break;
                        }
                    }
                }

                if (_rnd.Next(2) == 0)
                {
                    email = recipients[_rnd.Next(recipientsMax)].Email;
                    //AddDelegateForInbox(email);
                    newMsg.ReplyTo.Add(email);
                    if (_rnd.Next(2) == 0)
                    {
                        email = recipients[_rnd.Next(recipientsMax)].Email;
                        //AddDelegateForInbox(email);
                        newMsg.ReplyTo.Add(email);
                    }

                    if (_rnd.Next(2) == 0)
                    {
                        newMsg.Update(ConflictResolutionMode.AlwaysOverwrite);
                        bool toAll = Convert.ToBoolean(_rnd.Next(2));
                        ResponseMessage replMsg = newMsg.CreateReply(toAll);
                        replMsg.BodyPrefix = @"test body prefix for reply message";
                        //replMsg.Save(WellKnownFolderName.Drafts);

                        replMsg.ToRecipients.Add(recipients[_rnd.Next(recipientsMax)].Email);
                        if (_rnd.Next(2) == 0)
                            replMsg.ToRecipients.Add(recipients[_rnd.Next(recipientsMax)].Email);
                        
                        res.reply = replMsg;
                        // выбираем, какие поля заполнять:
                        //  - обычный список получателей
                        //  - теневую копию
                        //  - и то и другое
                        if (_rnd.Next(2) == 0)
                        {
                            switch (_rnd.Next(3))
                            {
                                case 0:
                                    // заполняем обычный список получателей
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    replMsg.CcRecipients.Add(email);
                                    if (_rnd.Next(2) == 0)
                                    {
                                        email = recipients[_rnd.Next(recipientsMax)].Email;
                                        //AddDelegateForInbox(email);
                                        replMsg.CcRecipients.Add(email);
                                    }
                                    break;
                                case 1:
                                    // заполняем теневую копию
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    replMsg.BccRecipients.Add(email);
                                    if (_rnd.Next(2) == 0)
                                    {
                                        email = recipients[_rnd.Next(recipientsMax)].Email;
                                        //AddDelegateForInbox(email);
                                        replMsg.BccRecipients.Add(email);
                                    }
                                    break;
                                default:
                                    // заполняем обычный список получателей
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    replMsg.CcRecipients.Add(email);
                                    if (_rnd.Next(2) == 0)
                                    {
                                        email = recipients[_rnd.Next(recipientsMax)].Email;
                                        //AddDelegateForInbox(email);
                                        replMsg.CcRecipients.Add(email);
                                    }
                                    // заполняем теневую копию
                                    email = recipients[_rnd.Next(recipientsMax)].Email;
                                    //AddDelegateForInbox(email);
                                    replMsg.BccRecipients.Add(email);
                                    if (_rnd.Next(2) == 0)
                                    {
                                        email = recipients[_rnd.Next(recipientsMax)].Email;
                                        //AddDelegateForInbox(email);
                                        replMsg.BccRecipients.Add(email);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                GenericLogger<Generator>.Error(
                    LocalizibleStrings.ErrorCreateFromTemplate + msg.FileName, exc);
            }
            return res;
        }*/
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private GenResult EmailMessageFromMessage(
            StoredContact sender,
            StoredContact recipient,
            Storage.Message msg)
        {
            GenResult res = new GenResult();
            try
            {
                EmailAddress em =
                    Contact.Bind(this.service, new ItemId(sender.UniqId))
                        .EmailAddresses[EmailAddressKey.EmailAddress1];

                EmailMessage newMsg = new EmailMessage(this.service)
                {
                    From = em,
                    Sender = em,
                    Body = new MessageBody(msg.BodyHtml),
                    Subject = msg.Subject
                };

                newMsg.Save(WellKnownFolderName.Drafts);

                foreach (object obj in msg.Attachments)
                {
                    Storage.Attachment attach = obj as Storage.Attachment;
                    if (attach == null)
                        continue;
                    newMsg.Attachments.AddFileAttachment(attach.FileName, attach.Data);
                }

                this.FillAdresses(ref newMsg, recipient.Email);

                res.msg = newMsg;

                // делаем ли форвард
                if (RndTrueFalse())
                {
                    newMsg.Update(ConflictResolutionMode.AlwaysOverwrite);
                    ResponseMessage respMsg = newMsg.CreateForward();
                    respMsg.BodyPrefix = @"test body prefix for forward message";
                    this.FillAdressesForResponse(ref respMsg, this.RndRecipMail());
                    respMsg.Save(WellKnownFolderName.Drafts);
                    res.response = respMsg;
                }

                // делаем ли реплай
                if (RndTrueFalse())
                {
                    /*newMsg.ReplyTo.Add(_RndRecipMail());
                    if (_RndTrueFalse())
                    {
                        newMsg.ReplyTo.Add(_RndRecipMail());
                    }

                    if (_RndTrueFalse()) */
                    {
                        newMsg.Update(ConflictResolutionMode.AlwaysOverwrite);
                        ResponseMessage replMsg = newMsg.CreateReply(RndTrueFalse());
                        replMsg.BodyPrefix = @"test body prefix for reply message";
                        this.FillAdressesForResponse(ref replMsg, recipient.Email);
                        replMsg.Save(WellKnownFolderName.Drafts);
                        res.reply = replMsg;
                    }
                }
            }
            catch (Exception exc)
            {
                GenericLogger<Generator>.Error(
                    LocalizibleStrings.ErrorCreateFromTemplate + msg.FileName, exc);
            }
            return res;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FillAdresses(ref EmailMessage newMsg, string recipient)
        {
            this.AddAdressesToCollection(newMsg.ToRecipients, recipient);

            // выбираем, какие поля заполнять:
            //  - копию
            //  - теневую копию
            //  - и то и другое
            if (!RndTrueFalse())
            {
                return;
            }

            switch (Rnd.Next(3))
            {
                case 0:
                    // заполняем обычный список получателей
                    this.AddAdressesToCollection(newMsg.CcRecipients);
                    break;
                case 1:
                    // заполняем теневую копию
                    this.AddAdressesToCollection(newMsg.BccRecipients);
                    break;
                default:
                    // заполняем обычный список получателей
                    this.AddAdressesToCollection(newMsg.CcRecipients);
                    this.AddAdressesToCollection(newMsg.BccRecipients);
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FillAdressesForResponse(ref ResponseMessage newMsg, string recipient)
        {
            this.AddAdressesToCollection(newMsg.ToRecipients, recipient);
            // выбираем, какие поля заполнять:
            //  - копию
            //  - теневую копию
            //  - и то и другое
            if (!RndTrueFalse())
            {
                return;
            }
            switch (Rnd.Next(3))
            {
                case 0:
                    // заполняем обычный список получателей
                    this.AddAdressesToCollection(newMsg.CcRecipients);
                    break;
                case 1:
                    // заполняем теневую копию
                    this.AddAdressesToCollection(newMsg.BccRecipients);
                    break;
                default:
                    // заполняем обычный список получателей
                    this.AddAdressesToCollection(newMsg.CcRecipients);
                    this.AddAdressesToCollection(newMsg.BccRecipients);
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddAdressesToCollection(
            EmailAddressCollection adresses,
            string firstAdress = null)
        {
            adresses.Add(firstAdress ?? this.RndRecipMail());
            if (RndTrueFalse() && this.recipientsMax > 1)
            {
                adresses.Add(this.RndRecipMail());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string RndRecipMail()
        {
            return this.recipients[Rnd.Next(this.recipientsMax)].Email;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool RndTrueFalse()
        {
            return Rnd.Next(2) == 0;
        }

        /*private void AddDelegateForInbox(string email)
        {
            //return;
            DelegateUser delegUser = new DelegateUser(Config.GetParam(Config.UserEmail));
            delegUser.Permissions.InboxFolderPermissionLevel =
                DelegateFolderPermissionLevel.Editor;

            Mailbox mailbox = new Mailbox(email);

            _service.AddDelegates(
                mailbox,
                MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe,
                delegUser);
        }*/

        internal void GenTasks(
            ref IList<StoredContact> contacts,
            ref IList<Storage.Task> templates,
            int targetTasksCount,
            Action progressCallback)
        {
            //try
            //{
            //    Task task = new Task(_service);
            //    task.

            //    IList<StoredContact> senders =
            //        contacts.Where(c => c.CanBeSender).ToList();

            //    if (senders.Count <= 0)
            //    {
            //        GenericLogger<Generator>.Error(LocalizibleStrings.SendersCount);
            //        return;
            //    }

            //    int sendersMax = senders.Count;

            //    IList<StoredContact> recipients =
            //        contacts.Where(c => c.CanBeRecipient).ToList();

            //    if (recipients.Count <= 0)
            //    {
            //        GenericLogger<Generator>.Error(LocalizibleStrings.RecipientsCount);
            //        return;
            //    }

            //    Random _rnd = new Random();
            //    int recipientsMax = recipients.Count;

            //    //int templatesCount = templates.Count - 1;

            //    int sendedCount = 0;

            //    List<GenResult> genMsgs =
            //        new List<GenResult>(recipientsMax * mailsCountPerRecipient);

            //    int mailsCountTotal = mailsCountPerRecipient * recipientsMax;

            //    #region Old algorithm
            //    // если хотят больше, чем есть шаблонов
            //    if (mailsCountPerRecipient >= templates.Count)
            //    {
            //        // генерируем по всем + дополнительные круги, сколько сможем
            //        while (sendedCount < mailsCountTotal)
            //        {
            //            foreach (Storage.Message msg in templates)
            //            {
            //                Storage.Message locMsg = msg;
            //                GenResult newMsg =
            //                    this.EmailMessageFromMessage(
            //                        ref senders, sendersMax,
            //                        ref recipients, recipientsMax,
            //                        ref _rnd, ref locMsg);

            //                if (newMsg.msg == null)
            //                    break;

            //                genMsgs.Add(newMsg);
            //                sendedCount++;

            //                if (newMsg.reply != null)
            //                    sendedCount++;

            //                if (newMsg.response != null)
            //                    sendedCount++;

            //                GenericLogger<Generator>.Message(
            //                    LocalizibleStrings.MsgCreatedOf, sendedCount, mailsCountPerRecipient);

            //                progressCallback.BeginInvoke(null, null);

            //                // если уже сгенерировали сколько надо
            //                if (sendedCount == mailsCountPerRecipient)
            //                    break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        while (sendedCount <= mailsCountTotal)
            //        {
            //            Storage.Message msg = templates[_rnd.Next(templates.Count)];

            //            if (msg == null)
            //                continue;

            //            GenResult newMsg =
            //                this.EmailMessageFromMessage(
            //                    ref senders, sendersMax,
            //                    ref recipients, recipientsMax,
            //                    ref _rnd, ref msg);

            //            if (newMsg.msg == null)
            //                break;

            //            genMsgs.Add(newMsg);

            //            sendedCount++;

            //            if (newMsg.reply != null)
            //                sendedCount++;

            //            if (newMsg.response != null)
            //                sendedCount++;

            //            GenericLogger<Generator>.Message(
            //                LocalizibleStrings.MsgCreatedOf, sendedCount, mailsCountPerRecipient);

            //            progressCallback.BeginInvoke(null, null);
            //        }
            //    }
            //    #endregion

            //    /*for(int recipientIndex = 0; recipientIndex <= recipientsMax; recipientIndex++)
            //    {
            //        for (int templateIndex = 0; templateIndex <= templatesCount; templateIndex++)
            //        {

            //        }
            //    }*/

            //    GenericLogger<Generator>.Message(LocalizibleStrings.MsgSendingStarted);
            //    genMsgs.AsParallel().ForAll(res =>
            //    {
            //        res.msg.Send();
            //        if (res.response != null)
            //            res.response.Send();
            //        if (res.reply != null)
            //            res.reply.Send();
            //    });
            //    GenericLogger<Generator>.Message(LocalizibleStrings.MsgSendingFinished);
            //}
            //catch (Exception exc)
            //{
            //    GenericLogger<Generator>.Error(
            //        LocalizibleStrings.ErrorGenMailMsg, exc);
            //}
        }
    }
}
