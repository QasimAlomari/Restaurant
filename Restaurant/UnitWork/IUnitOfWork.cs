using Restaurant.Models.Repositories;
using Restaurant.Models;

namespace Restaurant.UnitWork
{
    public interface IUnitOfWork
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
    }
}
