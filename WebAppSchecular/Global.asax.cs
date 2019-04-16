using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;
using WebAppSchecular.CustomJob;

namespace WebAppSchecular
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			new Scheduler().Start();
		}
	}

	public class Scheduler
	{
		public void Start()
		{
			// construct a scheduler factory
			ISchedulerFactory schedFact = new StdSchedulerFactory();

			// get a scheduler, start the schedular before triggers or anything else
			IScheduler sched = schedFact.GetScheduler();
			sched.Start();

			// create job
			IJobDetail job = JobBuilder.Create<SimpleJob>()
					.WithIdentity("job1", "group1")
					.Build();

			// create trigger
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity("trigger1", "group1")
				.WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
				.Build();

			// Schedule the job using the job and trigger 
			sched.ScheduleJob(job, trigger);
		}
	}

	public class SimpleJob : IJob
	{
		void IJob.Execute(IJobExecutionContext context)
		{
			new ProjectFuctions().DoSomething();
		}
	}
}
