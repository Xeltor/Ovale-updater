using LibGit2Sharp;
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
        internal Task<string> Update(string v)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> Clone(string GithubUsername, string GithubRepo)
        {
            try
            {
                Repository.Clone($"https://github.com/{GithubUsername}/{GithubRepo}.git", $"D:\\Workspace\\Fakewow\\interface\\addons\\{GithubRepo}");
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        internal Task<string> Log(string GithubUsername, string GithubRepo)
        {
            string log = "";

            using (var repo = new Repository($"D:\\Workspace\\Fakewow\\interface\\addons\\{GithubRepo}"))
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
                    log += c.Message.Replace("\n", Environment.NewLine);
                    log += Environment.NewLine;
                }
            }

            return Task.FromResult(log);
        }
    }
}
