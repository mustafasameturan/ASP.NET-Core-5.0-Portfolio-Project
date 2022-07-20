using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule  : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().SingleInstance();

            builder.RegisterType<ContactInformationManager>().As<IContactInformationService>().SingleInstance();
            builder.RegisterType<EfContactInformationDal>().As<IContactInformationDal>().SingleInstance();

            builder.RegisterType<ContactMessageManager>().As<IContactMessageService>().SingleInstance();
            builder.RegisterType<EfContactMessageDal>().As<IContactMessageDal>().SingleInstance();

            builder.RegisterType<ExperienceManager>().As<IExperienceService>().SingleInstance();
            builder.RegisterType<EfExperienceDal>().As<IExperienceDal>().SingleInstance();

            builder.RegisterType<MainPageManager>().As<IMainPageService>().SingleInstance();
            builder.RegisterType<EfMainPageDal>().As<IMainPageDal>().SingleInstance();

            builder.RegisterType<PortfolioManager>().As<IPortfolioService>().SingleInstance();
            builder.RegisterType<EfPortfolioDal>().As<IPortfolioDal>().SingleInstance();

            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<EfServiceDal>().As<IServiceDal>().SingleInstance();

            builder.RegisterType<SkillManager>().As<ISkillService>().SingleInstance();
            builder.RegisterType<EfSkillDal>().As<ISkillDal>().SingleInstance();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>().SingleInstance();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>().SingleInstance();

            builder.RegisterType<UserMessageManager>().As<IUserMessageService>().SingleInstance();
            builder.RegisterType<EfUserMessageDal>().As<IUserMessageDal>().SingleInstance();

            builder.RegisterType<PortfolioValidator>().SingleInstance();
            builder.RegisterType<ExperienceValidator>().SingleInstance();
            builder.RegisterType<ServiceValidator>().SingleInstance();
            builder.RegisterType<SkillValidator>().SingleInstance();
            builder.RegisterType<SocialMediaValidator>().SingleInstance();
            builder.RegisterType<AnnouncementValidator>().SingleInstance();
            
        }
    }
}
