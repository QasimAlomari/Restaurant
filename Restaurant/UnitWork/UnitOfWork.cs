using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<MasterMenu> MasterMenuRepository { get; }
        public IRepository<MasterSlider> MasterSliderRepository { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHourRepository { get; }
        public IRepository<MasterPartner> MasterPartnerRepository { get; }
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletterRepository { get; }
        public IRepository<TransactionBookTable> TransactionBookTableRepository { get; }
        public IRepository<TransactionContactUs> TransactionContactUsRepository { get; }
        public IRepository<MasterAbout> MasterAboutRepository { get; }
        public IRepository<MasterOffer> MasterOfferRepository { get; }
        public IRepository<SystemSetting> SystemSettingRepository { get; }
        public IRepository<MasterService> MasterServiceRepository { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformationRepository { get; }
        public IRepository<MasterSocialMedia> MasterSocialMediaRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }


        public UnitOfWork(

                    IRepository<MasterMenu> MasterMenuRepository,
                    IRepository<MasterSlider> MasterSliderRepository,
                    IRepository<MasterWorkingHour> MasterWorkingHourRepository,
                    IRepository<MasterPartner> MasterPartnerRepository,
                    IRepository<MasterItemMenu> MasterItemMenuRepository,
                    IRepository<TransactionNewsletter> TransactionNewsletterRepository,
                    IRepository<TransactionBookTable> TransactionBookTableRepository,
                    IRepository<TransactionContactUs> TransactionContactUsRepository,
                    IRepository<MasterAbout> MasterAboutRepository,
                    IRepository<MasterOffer> MasterOfferRepository,
                    IRepository<SystemSetting> SystemSettingRepository,
                    IRepository<MasterService> MasterServiceRepository,
                    IRepository<MasterContactUsInformation> MasterContactUsInformationRepository,
                    IRepository<MasterSocialMedia> MasterSocialMediaRepository,
                    IRepository<MasterCategoryMenu> MasterCategoryMenuRepository

            )
        {
            this.MasterMenuRepository = MasterMenuRepository;
            this.MasterSliderRepository = MasterSliderRepository;
            this.MasterWorkingHourRepository = MasterWorkingHourRepository;
            this.MasterPartnerRepository = MasterPartnerRepository;
            this.MasterItemMenuRepository = MasterItemMenuRepository;
            this.TransactionNewsletterRepository = TransactionNewsletterRepository;
            this.TransactionBookTableRepository = TransactionBookTableRepository;
            this.TransactionContactUsRepository = TransactionContactUsRepository;
            this.MasterAboutRepository = MasterAboutRepository;
            this.MasterOfferRepository = MasterOfferRepository;
            this.SystemSettingRepository = SystemSettingRepository;
            this.MasterServiceRepository = MasterServiceRepository;
            this.MasterContactUsInformationRepository = MasterContactUsInformationRepository;
            this.MasterSocialMediaRepository = MasterSocialMediaRepository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
        }
    }
}
