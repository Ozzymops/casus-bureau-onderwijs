﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// DELETE
using System.Diagnostics;

namespace BureauOnderwijs.Views
{
    public partial class Roosteroverzicht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On first load...
            if ((bool)Session["Database_FirstTime"])
            {
                // Initieer Sessions
                Session["Database_Changed"] = false;
                Session["User_Changed"] = false;

                // Genereer data voor de eerste keer         
                GenerateStaticLists();
                RetrieveData();
                ImportData();

                // Verstop edit panel
                add_controls.Visible = true;
                edit_controls.Visible = false;

                Session["Database_FirstTime"] = false;
            }

            if (Session["RoleId"] != null)
            {
                if ((int)Session["RoleId"] == 1)
                {
                    controls.Visible = true;
                    show_wishes.Visible = true;
                }
                else
                {
                    controls.Visible = false;
                    show_wishes.Visible = false;
                }
            }
            else
            {
                controls.Visible = false;
                show_wishes.Visible = false;
            }

        }

        #region Methods
        /// <summary>
        /// Genereer Columns en Rows voor MainGridView.
        /// </summary>
        private void GenerateMainGridView()
        {
            // DataTable voor tijdelijke opslag Columns en Rows
            DataTable dataTable = new DataTable();

            // Maak Columns als deze er niet zijn
            if (MainGridView.Columns.Count == 0)
            {
                dataTable.Columns.Add("Tijd", typeof(string));
                dataTable.Columns.Add("Maandag", typeof(string));
                dataTable.Columns.Add("Dinsdag", typeof(string));
                dataTable.Columns.Add("Woensdag", typeof(string));
                dataTable.Columns.Add("Donderdag", typeof(string));
                dataTable.Columns.Add("Vrijdag", typeof(string));
            }

            // Maak Rows als deze er niet zijn
            if (MainGridView.Rows.Count == 0)
            {
                int minHour = 9;            // vroegste tijd = 09:00
                int maxHour = 18;           // laatste tijd = 18:00
                int currentHour = minHour;  // huidige uur om te plaatsen
                bool halfHour = false;      // plaats een half uur?

                for (int t = 0; t <= maxHour; t++)
                {
                    // DataRow voor een tijdelijke Row om in de DataTable te plaatsen
                    DataRow dataRow = dataTable.NewRow();
                    if (halfHour)
                    {
                        dataRow["Tijd"] = currentHour + ":30";
                        currentHour++;
                    }
                    else
                    {
                        dataRow["Tijd"] = currentHour + ":00";
                    }
                    halfHour = !halfHour;
                    dataTable.Rows.Add(dataRow);
                }
            }

            // Voeg Columns en Rows toe aan de MainGridView
            MainGridView.DataSource = dataTable;
            MainGridView.DataBind();
        }

        /// <summary>
        /// Genereer Columns en Rows voor EditGridView.
        /// </summary>
        private void GenerateEditGridView()
        {
            // DataTable voor tijdelijke opslag Columns en Rows
            DataTable dataTable = new DataTable();

            // Maak Columns als deze er niet zijn
            if (EditGridView.Columns.Count == 0)
            {
                dataTable.Columns.Add("LesId", typeof(int));
                dataTable.Columns.Add("DocentId", typeof(int));
                dataTable.Columns.Add("Module", typeof(string));
                dataTable.Columns.Add("Lokaal", typeof(string));
                dataTable.Columns.Add("Groep", typeof(string));
                dataTable.Columns.Add("Blok", typeof(int));
                dataTable.Columns.Add("Week", typeof(int));
                dataTable.Columns.Add("Dag", typeof(int));
                dataTable.Columns.Add("Start [H]", typeof(int));
                dataTable.Columns.Add("Start [M]", typeof(int));
                dataTable.Columns.Add("Eind [H]", typeof(int));
                dataTable.Columns.Add("Eind [M]", typeof(int));
            }

            // Maak Rows als deze er niet zijn
            if (EditGridView.Rows.Count == 0)
            {
                LectureIdDropdownList.Items.Clear();
                int lectureId = 1;
                //FEEDBACK RB-> Hier ga je direct van GUI naar BU, terwijl jullie in 5 lagen werken.
                //Hiermee sla je dus een laag over!
                //Daarnaast bevat de GUI op deze manier erg veel logica, wat niet gewenst is.
                List<Models.BU.Lecture> lectureList = (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue];
                if (lectureList != null || lectureList.Count == 0)
                {
                    LectureLabel.Text = "Lectures gevonden voor docent " + UserDropdownList.SelectedValue;
                    foreach (Models.BU.Lecture lecture in (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue])
                    {
                        if (UserDropdownList.SelectedValue == lecture.teacher.UserID.ToString() && PeriodDropdownList.SelectedValue == lecture.period.ToString() && WeekDropdownList.SelectedValue == lecture.week.ToString())
                        {
                            LectureIdDropdownList.Items.Add(lectureId.ToString());
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["LesId"] = lectureId;
                            dataRow["DocentId"] = lecture.teacher.UserID;
                            dataRow["Module"] = lecture.module.moduleCode;
                            dataRow["Lokaal"] = lecture.classroom;
                            dataRow["Groep"] = lecture.studentGroup;
                            dataRow["Blok"] = lecture.period;
                            dataRow["Week"] = lecture.week;
                            dataRow["Dag"] = lecture.day;
                            dataRow["Start [H]"] = lecture.startHour;
                            dataRow["Start [M]"] = lecture.startMinute;
                            dataRow["Eind [H]"] = lecture.endHour;
                            dataRow["Eind [M]"] = lecture.endMinute;
                            dataTable.Rows.Add(dataRow);
                            lectureId++;
                        }
                    }
                }
            }

            // Voeg Columns en Rows toe aan de MainGridView
            EditGridView.DataSource = dataTable;
            EditGridView.DataBind();

            // Reset positie van LectureDropdownList
            LectureIdDropdownList.SelectedIndex = -1;
        }

        /// <summary>
        /// Genereer Columns en Rows voor WishGridView
        /// </summary>
        private void GenerateWishGridView()
        {
            // DataTable voor tijdelijke opslag Columns en Rows
            DataTable dataTable = new DataTable();

            // Maak Columns als deze er niet zijn
            if (WishGridView.Columns.Count == 0)
            {
                dataTable.Columns.Add("WensId", typeof(int));
                dataTable.Columns.Add("DocentId", typeof(int));
                dataTable.Columns.Add("Blok", typeof(int));
                dataTable.Columns.Add("Week", typeof(int));
                dataTable.Columns.Add("Dag", typeof(string));
                dataTable.Columns.Add("Start", typeof(string));
                dataTable.Columns.Add("Eind", typeof(string));
            }

            // Maak Rows als deze er niet zijn
            if (WishGridView.Rows.Count == 0)
            {
                List<Models.BU.Wish> wishList = (List<Models.BU.Wish>)Session["Database_Wishes_" + UserDropdownList.SelectedValue];
                if (wishList != null || wishList.Count == 0)
                {
                    //FEEDBACK RB
                    //Membervariabelen zouden niet public moeten zijn. Dus uit gecommentarieerd in Wish
                    //Daardoor werkt dit nu niet meer.

                    
                    WishLabel.Text = "Wishes gevonden voor docent " + UserDropdownList.SelectedValue;
                    foreach (Models.BU.Wish wish in (List<Models.BU.Wish>)Session["Database_Wishes_" + UserDropdownList.SelectedValue])
                    {
                        /* //FEEDBACK RB -> Commentaar van gemaakt
                        if (UserDropdownList.SelectedValue == wish.userId.ToString() && PeriodDropdownList.SelectedValue == wish.period.ToString() && WeekDropdownList.SelectedValue == wish.week.ToString())
                        {

                            DataRow dataRow = dataTable.NewRow();
                            dataRow["WensId"] = wish.WishId;
                            dataRow["DocentId"] = wish.userId;
                            dataRow["Blok"] = wish.period;
                            dataRow["Week"] = wish.week;
                            dataRow["Dag"] = DayString(wish.day);
                            dataRow["Start"] = TimeString(wish.startHour, wish.startMinute);
                            dataRow["Eind"] = TimeString(wish.endHour, wish.endMinute);
                            dataTable.Rows.Add(dataRow);
                        }
                        */
                    }
                }
            }

            // Voeg Columns en Rows toe aan de MainGridView
            WishGridView.DataSource = dataTable;
            WishGridView.DataBind();
        }

        /// <summary>
        /// Vul de edit textboxes e.d. met data uit EditGridView.
        /// </summary>
        private void FillEditElements()
        {
            // Leeg eerst alles
            ModuleDropdownList_E.SelectedValue = null;
            ClassroomTextBox_E.Text = "";
            StudentGroupTextBox_E.Text = "";
            DayDropdownList_E.SelectedValue = null;
            TimeStartHourTextBox_E.Text = "";
            TimeStartMinuteTextBox_E.Text = "";
            TimeEndHourTextBox_E.Text = "";
            TimeEndMinuteTextBox_E.Text = "";

            if (LectureIdDropdownList != null)
            {
                if (EditGridView != null)
                {
                    foreach (GridViewRow row in EditGridView.Rows)
                    {
                        // Check of de LectureId overeenkomt
                        if (row.Cells[0].Text == LectureIdDropdownList.SelectedValue.ToString())
                        {
                            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

                            int selectedModuleId = get.GetModuleByModuleCode(row.Cells[2].Text).moduleId;
                            ModuleDropdownList_E.SelectedValue = selectedModuleId.ToString();
                            ClassroomTextBox_E.Text = row.Cells[3].Text;
                            StudentGroupTextBox_E.Text = row.Cells[4].Text;
                            DayDropdownList_E.SelectedValue = DayString(Convert.ToInt32(row.Cells[7].Text));
                            TimeStartHourTextBox_E.Text = row.Cells[8].Text;
                            TimeStartMinuteTextBox_E.Text = row.Cells[9].Text;
                            TimeEndHourTextBox_E.Text = row.Cells[10].Text;
                            TimeEndMinuteTextBox_E.Text = row.Cells[11].Text;

                            // Sla de oude data op naar oldLecture
                            Session["Database_SelectedLectureData"] = new Models.BU.Lecture(get.GetSingleTeacher(Convert.ToInt32(UserDropdownList.SelectedValue)), get.GetSingleModule(Convert.ToInt32(ModuleDropdownList_E.SelectedValue)), ClassroomTextBox_E.Text, StudentGroupTextBox_E.Text, Convert.ToInt32(PeriodDropdownList.SelectedValue), Convert.ToInt32(WeekDropdownList.SelectedValue), DayInt(DayDropdownList_E.SelectedValue), Convert.ToInt32(TimeStartHourTextBox_E.Text), Convert.ToInt32(TimeStartMinuteTextBox_E.Text), Convert.ToInt32(TimeEndHourTextBox_E.Text), Convert.ToInt32(TimeEndMinuteTextBox_E.Text));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Vul UserDropdownList, PeriodDropdownList en WeekDropdownList.
        /// </summary>
        private void GenerateStaticLists()
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            // Vul UserDropdownList
            Session["Database_Teachers"] = get.GetTeacherList();
            UserDropdownList.DataSource = Session["Database_Teachers"];
            UserDropdownList.DataValueField = "userId";
            UserDropdownList.DataTextField = "username";
            UserDropdownList.DataBind();

            // Vul PeriodDropdownList
            for (int p = 1; p <= 4; p++)
            {
                PeriodDropdownList.Items.Add(p.ToString());
            }

            // Vul WeekDropdownList
            for (int w = 1; w <= 10; w++)
            {
                WeekDropdownList.Items.Add(w.ToString());
            }

            // Stel default waarden in
            Session["User_Current"] = UserDropdownList.Items[0];
            Session["Period_Current"] = PeriodDropdownList.Items[0];
            Session["Week_Current"] = WeekDropdownList.Items[0];
        }

        /// <summary>
        /// Vul DayDropdownList en ModuleDropdownList en de edit equivalenten.
        /// </summary>
        private void GenerateDynamicLists()
        {
            // DayDropdownList en DayDropdownList_E
            DayDropdownList.Items.Clear();
            DayDropdownList_E.Items.Clear();
            List<Models.BU.Wish> wishList = (List<Models.BU.Wish>)Session["Database_Wishes_" + UserDropdownList.SelectedValue];
            if (wishList.Count != 0)
            {
                foreach (Models.BU.Wish wish in wishList)
                {
                    /* //FEEDBACK RB -> Zelfde reden als hierboven -> Public fields
                    if (PeriodDropdownList.SelectedValue == wish.period.ToString() && WeekDropdownList.SelectedValue == wish.week.ToString())
                    {
                        if (DayDropdownList.Items.FindByText(DayString(wish.day)) == null)
                        {
                            DayDropdownList.Items.Add(DayString(wish.day));
                            DayDropdownList_E.Items.Add(DayString(wish.day));
                        }
                    }
                    */
                }
            }

            // ModuleDropdownList en ModuleDropdownList_E
            ModuleDropdownList.Items.Clear();
            ModuleDropdownList_E.Items.Clear();
            List<Models.BU.Module> moduleList = (List<Models.BU.Module>)Session["Database_Modules_" + UserDropdownList.SelectedValue];
            ModuleDropdownList.DataSource = moduleList;
            ModuleDropdownList_E.DataSource = moduleList;
            ModuleDropdownList.DataValueField = "ModuleId";
            ModuleDropdownList_E.DataValueField = "ModuleId";
            ModuleDropdownList.DataTextField = "ModuleCode";
            ModuleDropdownList_E.DataTextField = "ModuleCode";
            ModuleDropdownList.DataBind();
            ModuleDropdownList_E.DataBind();
        }

        /// <summary>
        /// Importeer data uit de DB in MainGridView.
        /// </summary>
        private void ImportData()
        {
            // Regenereer MainGridView
            MainGridView.DataSource = null;
            MainGridView.DataBind();
            GenerateMainGridView();

            // Haal DB data op
            if ((bool)Session["Database_FirstTime"] || (bool)Session["User_Changed"] || (bool)Session["Database_Changed"])
            {
                RetrieveData();
                Session["User_Changed"] = false;
                Session["Database_Changed"] = false;
            }

            // Vul dynamische lijsten
            GenerateDynamicLists();

            // Plaats DB data in MainGridView
            List<Models.BU.Lecture> lectureList = (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue];
            if (lectureList != null)
            {
                foreach (Models.BU.Lecture lecture in (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue])
                {
                    if (UserDropdownList.SelectedValue == lecture.teacher.UserID.ToString() && PeriodDropdownList.SelectedValue == lecture.period.ToString() && WeekDropdownList.SelectedValue == lecture.week.ToString())
                    {
                        int[] cell = DetermineCell(lecture);
                        string newEntry = ConstructScheduleString(lecture);
                        MainGridView.Rows[cell[0]].Cells[cell[1]].Text = newEntry;
                    }
                }
            }

            // Plaats DB data in EditGridView en LectureIdDropdownList
            EditGridView.DataSource = null;
            EditGridView.DataBind();
            GenerateEditGridView();
            FillEditElements();

            // Plaats DB data in WishGridView
            WishGridView.DataSource = null;
            WishGridView.DataBind();
            GenerateWishGridView();

            // Bereken ingezette uren van docent.
            CalculateDeployedHours();
        }

        /// <summary>
        /// Haal data uit de DB op en plaats deze in een Sessions.
        /// </summary>
        private void RetrieveData()
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            // LECTURES
            // Maak / get Session
            if (Session["Database_Lectures_" + UserDropdownList.SelectedValue] == null || (bool)Session["Database_Changed"])
            {
                Session["Database_Lectures_" + UserDropdownList.SelectedValue] = new List<Models.BU.Lecture>();
            }
            List<Models.BU.Lecture> sessionLectureList = (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue];

            // Haal data op - voer alleen uit wanneer sessionList leeg is of als er wijzigingen zijn.
            if (sessionLectureList.Count == 0 || (bool)Session["Database_Changed"])
            {
                List<Models.BU.Lecture> lectureList = get.GetLecturesOfTeacher(Convert.ToInt32(UserDropdownList.SelectedValue));
                if (lectureList != null)
                {
                    foreach (Models.BU.Lecture lecture in lectureList)
                    {
                        if (!sessionLectureList.Contains(lecture))
                        {
                            sessionLectureList.Add(lecture);
                        }
                    }
                }
            }
            Session["Database_Lectures_" + UserDropdownList.SelectedValue] = sessionLectureList;

            // WISHES
            // Maak / get Session
            if (Session["Database_Wishes_" + UserDropdownList.SelectedValue] == null)
            {
                Session["Database_Wishes_" + UserDropdownList.SelectedValue] = new List<Models.BU.Wish>();
            }
            List<Models.BU.Wish> sessionWishList = (List<Models.BU.Wish>)Session["Database_Wishes_" + UserDropdownList.SelectedValue];

            // Haal data op - voer alleen uit wanneer sessionList leeg is of als er wijzigingen zijn.
            if (sessionWishList.Count == 0 || (bool)Session["Database_Changed"])
            {
                List<Models.BU.Wish> wishList = get.GetTeacherWishes(Convert.ToInt32(UserDropdownList.SelectedValue));
                if (wishList != null)
                {
                    foreach (Models.BU.Wish wish in wishList)
                    {
                        if (!sessionWishList.Contains(wish))
                        {
                            sessionWishList.Add(wish);
                        }
                    }
                }
            }
            Session["Database_Wishes_" + UserDropdownList.SelectedValue] = sessionWishList;

            // Modules
            // Maak / get Session
            if (Session["Database_Modules_" + UserDropdownList.SelectedValue] == null || (bool)Session["Database_Changed"])
            {
                Session["Database_Modules_" + UserDropdownList.SelectedValue] = new List<Models.BU.Module>();
            }
            List<Models.BU.Module> sessionModuleList = (List<Models.BU.Module>)Session["Database_Modules_" + UserDropdownList.SelectedValue];

            // Haal data op - voer alleen uit wanneer sessionList leeg is of als er wijzigingen zijn.
            if (sessionModuleList.Count == 0 || (bool)Session["Database_Changed"])
            {
                List<Models.BU.Module> moduleList = get.GetModuleListOfTeacher(Convert.ToInt32(UserDropdownList.SelectedValue));
                if (moduleList != null)
                {
                    foreach (Models.BU.Module module in moduleList)
                    {
                        if (!sessionModuleList.Contains(module))
                        {
                            sessionModuleList.Add(module);
                        }
                    }
                }
            }
            Session["Database_Modules_" + UserDropdownList.SelectedValue] = sessionModuleList;
        }

        /// <summary>
        /// Sla nieuwe data op in de DB en refresh alle data.
        /// </summary>
        private void SaveData(Models.BU.Lecture lecture)
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            int existingLectureId = get.CheckIfLectureAlreadyExists(lecture);
            if (existingLectureId == -1)
            {
                Models.CC.Scheduler_CreateEntry create = new Models.CC.Scheduler_CreateEntry();
                create.CreateEntry(lecture);
            }
            else
            {
                Models.CC.Scheduler_UpdateEntry update = new Models.CC.Scheduler_UpdateEntry();
                update.UpdateEntry(lecture, existingLectureId);
            }

            // Refresh
            Session["Database_Changed"] = true;
            ImportData();
        }

        /// <summary>
        /// Sla gewijzigde data op in de DB en refresh alle data.
        /// </summary>
        private void EditData(Models.BU.Lecture lecture)
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            int existingLectureId = get.CheckIfLectureAlreadyExists((Models.BU.Lecture)Session["Database_SelectedLectureData"]);
            if (existingLectureId != -1)
            {
                Models.CC.Scheduler_UpdateEntry update = new Models.CC.Scheduler_UpdateEntry();
                update.UpdateEntry(lecture, existingLectureId);
            }

            // Refresh
            Session["Database_Changed"] = true;
            ImportData();
        }

        /// <summary>
        /// Maak een Lecture om op te slaan in de DB.
        /// </summary>
        private void CreateLecture()
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            // Maak een object om te vullen.
            Models.BU.Lecture newLecture = new Models.BU.Lecture(
                get.GetSingleTeacher(Convert.ToInt32(UserDropdownList.SelectedValue)),  // Teacher
                get.GetSingleModule(Convert.ToInt32(ModuleDropdownList.SelectedValue)), // Module
                ClassroomTextBox.Text,                                                  // Classroom
                StudentGroupTextBox.Text,                                               // StudentGroup
                Convert.ToInt32(PeriodDropdownList.SelectedValue),                      // Period
                Convert.ToInt32(WeekDropdownList.SelectedValue),                        // Week
                DayInt(DayDropdownList.SelectedValue),                                  // Day
                Convert.ToInt32(TimeStartHourTextBox.Text),                             // StartHour
                Convert.ToInt32(TimeStartMinuteTextBox.Text),                           // StartMinute
                Convert.ToInt32(TimeEndHourTextBox.Text),                               // EndHour
                Convert.ToInt32(TimeEndMinuteTextBox.Text));                            // EndMinute

            // Opslaan
            SaveData(newLecture);
        }

        /// <summary>
        /// Update een Lecture in de DB.
        /// </summary>
        private void UpdateLecture()
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            // Maak een object om te vullen.
            Models.BU.Lecture updatedLecture = new Models.BU.Lecture(
                get.GetSingleTeacher(Convert.ToInt32(UserDropdownList.SelectedValue)),      // Teacher
                get.GetSingleModule(Convert.ToInt32(ModuleDropdownList_E.SelectedValue)),   // Module
                ClassroomTextBox_E.Text,                                                    // Classroom
                StudentGroupTextBox_E.Text,                                                 // StudentGroup
                Convert.ToInt32(PeriodDropdownList.SelectedValue),                          // Period
                Convert.ToInt32(WeekDropdownList.SelectedValue),                            // Week
                DayInt(DayDropdownList_E.SelectedValue),                                    // Day
                Convert.ToInt32(TimeStartHourTextBox_E.Text),                               // StartHour
                Convert.ToInt32(TimeStartMinuteTextBox_E.Text),                             // StartMinute
                Convert.ToInt32(TimeEndHourTextBox_E.Text),                                 // EndHour
                Convert.ToInt32(TimeEndMinuteTextBox_E.Text));                              // EndMinute

            // Opslaan
            EditData(updatedLecture);
        }

        /// <summary>
        /// Verwijder een Lecture uit de DB.
        /// </summary>
        private void DeleteLecture()
        {
            Models.CC.Scheduler_GetData get = new Models.CC.Scheduler_GetData();

            bool confirmed = true;  // maak default false!
            int existingLectureId = get.CheckIfLectureAlreadyExists((Models.BU.Lecture)Session["Database_SelectedLectureData"]);
            if (existingLectureId != -1)
            {
                // confirmation dialog
                if (confirmed)
                {
                    Models.CC.Scheduler_DeleteEntry delete = new Models.CC.Scheduler_DeleteEntry();
                    delete.DeleteEntry(existingLectureId);
                }
            }

            // Refresh
            Session["Database_Changed"] = true;
            ImportData();
        }

        /// <summary>
        /// Bereken de ingezette uren van een docent.
        /// </summary>
        private void CalculateDeployedHours()
        {
            List<Models.BU.Lecture> sessionLectureList = (List<Models.BU.Lecture>)Session["Database_Lectures_" + UserDropdownList.SelectedValue];
            double deployed = 0.0;
            foreach (Models.BU.Lecture lecture in sessionLectureList)
            {
                if (UserDropdownList.SelectedValue == lecture.teacher.UserID.ToString() && PeriodDropdownList.SelectedValue == lecture.period.ToString() && WeekDropdownList.SelectedValue == lecture.week.ToString())
                {
                    // Bereken verschil
                    int hours = lecture.endHour - lecture.startHour;
                    int minutes = lecture.endMinute - lecture.endHour;
                    deployed += hours + (minutes / 60);
                }
            }
            DeployedLabel.Text = "Ingezette uren deze week: " + deployed;
        }
        #endregion

        #region Data Conversion
        /// <summary>
        /// Maak een string dat past in een Cell van MainGridView uit een Lecture.
        /// </summary>
        public string ConstructScheduleString(Models.BU.Lecture lecture)
        {
            // string in MainGridView is altijd
            // [ DAG: START - EIND. ]
            // [ VAK, GROEP, LOKAAL.]
            return string.Format("{0}: {1} - {2}. {3}, {4}, {5}.",
                                DayString(lecture.day), TimeString(lecture.startHour, lecture.startMinute), TimeString(lecture.endHour, lecture.endMinute), lecture.module.moduleCode, lecture.studentGroup, lecture.classroom);
        }

        /// <summary>
        /// Bepaal in welke Cell Lecture kan worden geplaatst in MainGridView.
        /// </summary>
        public int[] DetermineCell(Models.BU.Lecture lecture)
        {
            int cellRow = -1;               // default waarde, buiten de tabel
            int cellColumn = lecture.day;   // waarde is dagnummer van Lecture

            // Bepaal cellRow
            switch (lecture.startHour)
            {
                case 9:
                    cellRow = 0;
                    break;
                case 10:
                    cellRow = 2;
                    break;
                case 11:
                    cellRow = 4;
                    break;
                case 12:
                    cellRow = 6;
                    break;
                case 13:
                    cellRow = 8;
                    break;
                case 14:
                    cellRow = 10;
                    break;
                case 15:
                    cellRow = 12;
                    break;
                case 16:
                    cellRow = 14;
                    break;
                case 17:
                    cellRow = 16;
                    break;
                case 18:
                    cellRow = 18;
                    break;
            }

            if (lecture.startHour != 18 && lecture.startMinute == 30)
            {
                cellRow += 1;
            }
            return new int[] { cellRow, cellColumn };
        }

        /// <summary>
        /// Zet een dag-int om naar een string.
        /// </summary>
        public string DayString(int day)
        {
            string[] dagen = { "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag" };
            switch (day)
            {
                case 1:
                    return dagen[0];
                case 2:
                    return dagen[1];
                case 3:
                    return dagen[2];
                case 4:
                    return dagen[3];
                case 5:
                    return dagen[4];
            }
            return null;
        }

        /// <summary>
        /// Zet een dag-string om naar een int.
        /// </summary>
        public int DayInt(string day)
        {
            switch (day)
            {
                case "Maandag":
                    return 1;
                case "Dinsdag":
                    return 2;
                case "Woensdag":
                    return 3;
                case "Donderdag":
                    return 4;
                case "Vrijdag":
                    return 5;
            }
            return 0;
        }

        /// <summary>
        /// Zet een uur/minuut combinatie om naar een string.
        /// </summary>
        public string TimeString(int hour, int minute)
        {
            if (minute != 0)
            {
                if (minute.ToString().Length == 1)
                {
                    return hour + ":0" + minute;
                }
                else
                {
                    return hour + ":" + minute;

                }
            }
            else
            {
                return hour + ":00";
            }
        }
        #endregion

        #region Buttons
        protected void UserDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["User_Changed"] = true;
            Session["User_Current"] = UserDropdownList.SelectedValue;
            ImportData();
        }

        protected void PeriodDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportData();
        }

        protected void WeekDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportData();
        }

        protected void LectureIdDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillEditElements();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            // Invoercontrole!
            //bool inputCheck = false;

            //FEEDBACK RB
            //Dat zijn wel heel veel if's achter elkaar. Dat kan netter (bijv. if-else if-else structuur, zie beneden)
            /*if (DayDropdownList.SelectedIndex != -1 || DayDropdownList.SelectedValue != null)
            {
                if (ModuleDropdownList.SelectedIndex != -1 || ModuleDropdownList.SelectedValue != null)
                {
                    if (!string.IsNullOrWhiteSpace(ClassroomTextBox.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(StudentGroupTextBox.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(TimeStartHourTextBox.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(TimeStartMinuteTextBox.Text))
                                {
                                    if (!string.IsNullOrWhiteSpace(TimeEndHourTextBox.Text))
                                    {
                                        if (!string.IsNullOrWhiteSpace(TimeEndMinuteTextBox.Text))
                                        {
                                            int number;
                                            if (Int32.TryParse(TimeStartHourTextBox.Text, out number))
                                            {
                                                if (Int32.TryParse(TimeStartMinuteTextBox.Text, out number))
                                                {
                                                    if (Int32.TryParse(TimeEndHourTextBox.Text, out number))
                                                    {
                                                        if (Int32.TryParse(TimeEndMinuteTextBox.Text, out number))
                                                        {
                                                            inputCheck = true;
                                                        }
                                                        else
                                                        {
                                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind minuut.');", true);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind uur.');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start minuut.');", true);
                                                }
                                            }
                                            else
                                            {
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start uur.');", true);
                                            }
                                        }
                                        else
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind minuut in.');", true);
                                        }
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind uur in.');", true);
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start minuut in.');", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start uur in.');", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klas in.');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klaslokaal in.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een module.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een dag.');", true);
            }

            if (inputCheck)
            {
                CreateLecture();
            }
            */

            if (DayDropdownList.SelectedIndex == -1 || DayDropdownList.SelectedValue == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een dag.');", true);
            }
            else if (ModuleDropdownList.SelectedIndex == -1 || ModuleDropdownList.SelectedValue == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een module.');", true);
            }
            else if (string.IsNullOrWhiteSpace(ClassroomTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klaslokaal in.');", true);
            }
            else if (string.IsNullOrWhiteSpace(StudentGroupTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klas in.');", true);
            }
            else if (string.IsNullOrWhiteSpace(TimeStartHourTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start uur in.');", true);
            }
            else if (string.IsNullOrWhiteSpace(TimeStartMinuteTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start minuut in.');", true);
            }
            else if (string.IsNullOrWhiteSpace(TimeEndHourTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind uur in.');", true);
            }
            else if (string.IsNullOrWhiteSpace(TimeEndMinuteTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind minuut in.');", true);
            }
            else if (!Int32.TryParse(TimeStartHourTextBox.Text, out int number))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start uur.');", true);
            }
            else if (!Int32.TryParse(TimeStartMinuteTextBox.Text, out number))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start minuut.');", true);
            }
            else if (!Int32.TryParse(TimeEndHourTextBox.Text, out number))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind uur.');", true);
            }
            else if (!Int32.TryParse(TimeEndMinuteTextBox.Text, out number))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind minuut.');", true);
            }
            else //Geen problemen, dus kan de lecture gecreerd worden.
            { 
                CreateLecture();
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //FEEDBACK RB
            //Zelfde invoercontrole als hierboven -> Methode van maken en maar 1 keer schrijven!

            // Invoercontrole!
            bool inputCheck = false;

            if (DayDropdownList_E.SelectedIndex != -1 || DayDropdownList_E.SelectedValue != null)
            {
                if (ModuleDropdownList_E.SelectedIndex != -1 || ModuleDropdownList_E.SelectedValue != null)
                {
                    if (!string.IsNullOrWhiteSpace(ClassroomTextBox_E.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(StudentGroupTextBox_E.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(TimeStartHourTextBox_E.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(TimeStartMinuteTextBox_E.Text))
                                {
                                    if (!string.IsNullOrWhiteSpace(TimeEndHourTextBox_E.Text))
                                    {
                                        if (!string.IsNullOrWhiteSpace(TimeEndMinuteTextBox_E.Text))
                                        {
                                            int number;
                                            if (Int32.TryParse(TimeStartHourTextBox_E.Text, out number))
                                            {
                                                if (Int32.TryParse(TimeStartMinuteTextBox_E.Text, out number))
                                                {
                                                    if (Int32.TryParse(TimeEndHourTextBox_E.Text, out number))
                                                    {
                                                        if (Int32.TryParse(TimeEndMinuteTextBox_E.Text, out number))
                                                        {
                                                            inputCheck = true;
                                                        }
                                                        else
                                                        {
                                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind minuut.');", true);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij eind uur.');", true);
                                                    }
                                                }
                                                else
                                                {
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start minuut.');", true);
                                                }
                                            }
                                            else
                                            {
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een getal in bij start uur.');", true);
                                            }
                                        }
                                        else
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind minuut in.');", true);
                                        }
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een eind uur in.');", true);
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start minuut in.');", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een start uur in.');", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klas in.');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een klaslokaal in.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een module.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kies a.u.b. een dag.');", true);
            }

            if (inputCheck)
            {
                UpdateLecture();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteLecture();
        }

        protected void PanelDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PanelDropdownList.SelectedIndex == 0)
            {
                add_controls.Visible = true;
                edit_controls.Visible = false;
            }
            else
            {
                add_controls.Visible = false;
                edit_controls.Visible = true;
            }
        }

        protected void ButtonFoutControle_Click(object sender, EventArgs e)
        {
            Models.CC.Scheduler_ShowConflicts ssc = new Models.CC.Scheduler_ShowConflicts();
            string returnvalueclassroom = ssc.ConflictsClassroomEmpty();
            string returnvalueteacher = ssc.ConflictsTeacherEmpty();
            string returnvaluestudentgroup = ssc.ConflictsStudentgroupEmpty();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Aantal Lessen zonder toegewezen lokaal: " + returnvalueclassroom + "\\nAantal Lessen zonder toegewezen docent: " + returnvalueteacher + "\\nAantal Lessen zonder toegewezen klas: " + returnvaluestudentgroup + "');", true);
        }
        #endregion
    }
}