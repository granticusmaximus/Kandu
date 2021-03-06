﻿using System.Text;

namespace Kandu.Services
{
    public class Teams : Service
    {
        public string Create(string name, string description = "")
        {
            if (!CheckSecurity()) { return AccessDenied(); } //check security
            
            return Success();
        }

        public string List()
        {
            if (!CheckSecurity()) { return AccessDenied(); } //check security
            var list = Query.Teams.GetList(User.userId);
            var html = new StringBuilder("{\"teams\":[");
            var i = 0;
            list.ForEach((Query.Models.Team t) =>
            {
                html.Append((i > 0 ? "," : "") + "{\"name\":\"" + t.name + "\", \"description\":\"" + t.description + "\",\"teamId\":\"" + t.teamId + "\"}");
                i++;
            });
            html.Append("]}");
            return html.ToString();
        }
    }
}
