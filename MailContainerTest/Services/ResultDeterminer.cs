using MailContainerTest.Types;

namespace MailContainerTest.Services
{
    public class ResultDeterminer : IResultDeterminer<MakeMailTransferResult>
    {
        public MakeMailTransferResult Determine(MakeMailTransferRequest request, MailContainer mailContainer)
        {
            var result = new MakeMailTransferResult();
            switch (request.MailType)
            {
                case MailType.StandardLetter:
                    if (mailContainer == null)
                    {
                        result.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
                    {
                        result.Success = false;
                    }
                    break;

                case MailType.LargeLetter:
                    if (mailContainer == null)
                    {
                        result.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                    {
                        result.Success = false;
                    }
                    else if (mailContainer.Capacity < request.NumberOfMailItems)
                    {
                        result.Success = false;
                    }
                    break;

                case MailType.SmallParcel:
                    if (mailContainer == null)
                    {
                        result.Success = false;
                    }
                    else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
                    {
                        result.Success = false;

                    }
                    else if (mailContainer.Status != MailContainerStatus.Operational)
                    {
                        result.Success = false;
                    }
                    break;
            }

            return result;
        }
    }
}
