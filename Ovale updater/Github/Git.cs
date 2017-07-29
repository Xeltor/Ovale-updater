using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using Ovale_updater.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovale_updater.Github
{
    public class Git
    {
        internal Task<bool> Update(Repo GithubRepo)
        {
            try
            {
                string logMessage = "";
                using (var repo = new Repository($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{GithubRepo}"))
                {
                    foreach (Remote remote in repo.Network.Remotes)
                    {
                        IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                        Commands.Fetch(repo, remote.Name, refSpecs, null, logMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        internal Task<string> CurrentVersion(Repo GithubRepo)
        {
            using (var repo = new Repository($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{GithubRepo}"))
            {
                string version = repo.Commits.First().Id.ToString();

                return Task.FromResult(version);
            }
        }

        internal Task<string> BrancheVersion(Repo GithubRepo)
        {
            using (var repo = new Repository($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{GithubRepo}"))
            {
                string version = repo.Branches.First().Commits.First().Id.ToString();

                return Task.FromResult(version);
            }
        }

        internal Task<bool> Clone(Repo GithubRepo)
        {
            try
            {
                Repository.Clone($"https://github.com/Xeltor/{GithubRepo}.git", $"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{GithubRepo}");
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        internal Task<string> Log(Repo GithubRepo)
        {
            string log = "";

            using (var repo = new Repository($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{GithubRepo}"))
            {
                var RFC2822Format = "ddd dd MMM HH:mm:ss yyyy K";

                foreach (Commit c in repo.Commits.Take(100))
                {
                    log += string.Format("Commit: {0}", c.Id) + Environment.NewLine;

                    if (c.Parents.Count() > 1)
                    {
                        log += string.Format("Merge: {0}", string.Join(" ", c.Parents.Select(p => p.Id.Sha.Substring(0, 7)).ToArray())) + Environment.NewLine;
                    }

                    log += string.Format("Author: {0} <{1}>", c.Author.Name, c.Author.Email) + Environment.NewLine;
                    log += string.Format("Date:   {0}", c.Author.When.ToString(RFC2822Format, CultureInfo.InvariantCulture)) + Environment.NewLine;
                    log += Environment.NewLine;
                    log += c.Message.TrimEnd().Replace("\n", Environment.NewLine) + Environment.NewLine;
                    log += "_________________________________________________________________" + Environment.NewLine + Environment.NewLine;
                }
            }

            return Task.FromResult(log);
        }
    }
}
