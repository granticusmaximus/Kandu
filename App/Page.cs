﻿namespace Kandu
{
    public class Page : Datasilk.Page
    {
        private Kandu.User _user = null;

        public User UserInfo
        {
            get
            {
                if (_user == null)
                {
                    _user = new Kandu.User(S);
                }
                return _user;
            }
        }

        public Page(global::Core DatasilkCore) : base(DatasilkCore) {
            title = "Kandu";
            description = "You can do everything you ever wanted";
        }

        public void LoadHeader(ref Scaffold scaffold)
        {
            scaffold.Child("header").Data["user"] = "1";
            if(S.User.photo == true)
            {
                scaffold.Child("header").Data["user-photo"] = "/users/" + S.Util.Str.DateFolders(S.User.datecreated) + "/photo.jpg";
            }
            else
            {
                scaffold.Child("header").Data["no-user"] = "1";
            }
        }
    }
}