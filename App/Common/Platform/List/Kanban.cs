﻿using System.Collections.Generic;
using System.Text;

namespace Kandu.Common.Platform.List
{
    public static class Kanban
    {
        public static string RenderList(Query.Models.List list, List<Query.Models.Card> cards)
        {
            //load html templates
            var view = new View("/Views/List/Kanban/list.html");
            var html = new StringBuilder();

            //set up each card
            foreach (var card in cards)
            {
                html.Append(Card.Kanban.RenderCard(card));
            }

            //set up list
            view["id"] = list.listId.ToString();
            view["title"] = list.name;
            view["items"] = html.ToString();

            //render list
            return view.Render();
        }
    }
}
