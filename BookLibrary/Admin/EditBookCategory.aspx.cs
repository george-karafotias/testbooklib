﻿using BookLibrary.Logic;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary.Admin
{
    public partial class EditBookCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errorPage = "~/404";
                ViewState["ReferrerUrl"] = Request.UrlReferrer.ToString();

                if (Request.Params.AllKeys.Contains("id"))
                {
                    int bookCategoryID = Convert.ToInt32(Request["id"]);
                    var db = new BookLibrary.Models.BookLibraryContext();
                    BookCategory bookCategory = db.BookCategories.First(a => a.BookCategoryID == bookCategoryID);
                    BookCategoryName.Text = bookCategory.BookCategoryName;
                    BookCategoryName.Focus();
                }
                else
                {
                    Response.Redirect(errorPage);
                }
            }
        }

        void ReturnToSender()
        {
            object referrer = ViewState["ReferrerUrl"];
            if (referrer != null)
                Response.Redirect((string)referrer);
            else
                Response.Redirect("Default.aspx");
        }

        protected void UpdateBookCategoryButton_Click(object sender, EventArgs e)
        {
            BookCategoriesLogic bclogic = new BookCategoriesLogic();
            bool saveSuccess = bclogic.UpdateBookCategory(Convert.ToInt32(Request["id"]), BookCategoryName.Text);
            if (saveSuccess)
            {
                ReturnToSender();
            }
            else
            {
                FailureText.Text = "Unable to update the book category.";
                ErrorMessage.Visible = true;
            }
        }
    }
}