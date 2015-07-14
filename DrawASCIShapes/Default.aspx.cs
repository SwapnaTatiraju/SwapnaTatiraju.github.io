using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace DrawASCIShapes
{
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// Page_Load Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateHistory();
            }
            catch (Exception e2)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = e2.ToString();
                throw;
            }
        }

        /// <summary>
        /// Drwa Button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Draw_Click(object sender, EventArgs e)
        {
            bool isSuccess= GenerateShape("DrawBtnClick");
            if (isSuccess)
            {
                SaveHistoryToFile();
                UpdateHistory();
            }
        }

        /// <summary>
        /// Method generating the shape patterns
        /// </summary>
        /// <param name="ShapeToDraw">String value indicating the shape</param>
        /// <returns>IsSuccess if the pattern generation is successful</returns>
        private bool GenerateShape(string ShapeToDraw)
        {
            try
            {
                bool isSuccess = true;

                string shapeDrawing = "";

                if (ShapeToDraw.Equals("DrawBtnClick"))
                {
                    shapeDrawing = RadioButtonList1.SelectedValue;
                }
                else
                {
                    shapeDrawing = ShapeToDraw;
                }

                switch (shapeDrawing)
                {
                    case "Square":
                        {
                            List<string> SquarePattern = GenerateSquare();
                            GridView1.DataSource = SquarePattern;
                            GridView1.DataBind();

                            Btn_Redraw.Visible = true;
                            Div_ShapeTextArea.Visible = true;

                            isSuccess = true;
                            break;
                        }
                    case "Rectangle":
                        {
                            List<string> RectanglePattern = GenerateRectangle();
                            GridView1.DataSource = RectanglePattern;
                            GridView1.DataBind();

                            Btn_Redraw.Visible = true;
                            Div_ShapeTextArea.Visible = true;

                            isSuccess = true;
                            break;
                        }
                    case "Triangle":
                        {
                            List<string> TrianglePattern = GenerateTriangle();
                            GridView1.DataSource = TrianglePattern;
                            GridView1.DataBind();

                            Btn_Redraw.Visible = true;
                            Div_ShapeTextArea.Visible = true;

                            isSuccess = true;
                            break;
                        }
                    case "Diamond-1":
                        {
                            List<string> DiamondPattern = GenerateDiamond1();
                            GridView1.DataSource = DiamondPattern;
                            GridView1.DataBind();

                            Btn_Redraw.Visible = true;
                            Div_ShapeTextArea.Visible = true;

                            isSuccess = true;
                            break;
                        }
                    case "Diamond-2":
                        {
                            if ((int.Parse(TxtBx_Height.Text) % 2 == 0))
                            {
                                lbl_Diamond2Err.Visible = true;
                                lbl_Diamond2Err.Text = "Please enter Odd number to display a Symmetric Diamond";
                                TxtBx_Height.Focus();

                                Btn_Redraw.Visible = false;
                                Div_ShapeTextArea.Visible = false;

                                isSuccess = false;
                                break;
                            }

                            List<string> DiamondPattern = GenerateDiamond2();
                            GridView1.DataSource = DiamondPattern;
                            GridView1.DataBind();

                            Btn_Redraw.Visible = true;
                            Div_ShapeTextArea.Visible = true;

                            isSuccess = true;
                            break;
                        }
                    default:
                        break;
                }

                return isSuccess;

            }
            catch (Exception e)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = e.ToString();
                throw;
            }
        }

        /// <summary>
        /// Method writing the user input to a file and saving it.
        /// </summary>
        private void SaveHistoryToFile()
        {
            try
            {
                //string fileName = @"C:\Users\Public\ASCIShapeGeneratorHistory.txt";

                string path = Server.MapPath("~/App_Data/ASCIShapeGeneratorHistory.txt");
                File.AppendAllText(path, "Shape:" + RadioButtonList1.SelectedValue + ", Height:" + TxtBx_Height.Text + ", Display Lable:" +
                        TXtBx_DisplayLable.Text + ", Label RowNum:" + TxtBx_rowNum.Text);

                //using (StreamWriter file = new StreamWriter(fileName, true))
                //{
                //    file.WriteLine("Shape:" + RadioButtonList1.SelectedValue + ", Height:" + TxtBx_Height.Text + ", Display Lable:" +
                //        TXtBx_DisplayLable.Text + ", Label RowNum:" + TxtBx_rowNum.Text);

                //}
            }
            catch (Exception exe)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = exe.ToString();
                throw;
            }
        }

        /// <summary>
        /// Method which updates the UserHistory tab for re-drawing the shape
        /// </summary>
        private void UpdateHistory()
        {
            try
            {
                string path = Server.MapPath("~/App_Data/ASCIShapeGeneratorHistory.txt");
                List<string> userHistory = new List<string>();

                if (System.IO.File.Exists(path))
                {
                    userHistory = File.ReadAllLines(path).ToList();
                }

                if (userHistory.Count == 0)
                {
                    Btn_ClearHistory.Visible = false;
                    Panel1.Visible = false;
                }
                else
                {
                    Btn_ClearHistory.Visible = true;
                    Panel1.Visible = true;
                }

                userHistory = userHistory.Distinct().ToList();
                BList_userHistory.Items.Clear();
                foreach (string item in userHistory)
                {
                    BList_userHistory.Items.Add(new ListItem(item));
                }
            }
            catch (Exception e)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = e.ToString();
                throw;
            }
        }

        /// <summary>
        /// Method calling the method on the WCF service to generate Square Pattern.
        /// This method also makes sure only the relevent data is displayed
        /// </summary>
        /// <returns>A List<string> which acts a datasource to the Gridview to display shape</string></returns>
        private List<string> GenerateSquare()
        {
            int height = int.Parse(TxtBx_Height.Text);
            List<string> SquarePattern = new List<string>();
            int TxtRowNum = 0;
            string rowString = "";

            if (!string.IsNullOrEmpty(TxtBx_rowNum.Text))
            {
                TxtRowNum = int.Parse(TxtBx_rowNum.Text);
            }

            //ASCIShapeServiceReference1.ASCIService1Client client = new ASCIShapeServiceReference1.ASCIService1Client();
            //SquarePattern = client.GenerateSquare(height, TXtBx_DisplayLable.Text, TxtRowNum).ToList();

            #region Generate Square Code

            for (int i = 0; i < height; i++)
            {
                List<string> rows = new List<string>();
                for (int j = 0; j < height; j++)
                {
                    rows.Add("X");
                }

                if ((!string.IsNullOrEmpty(TXtBx_DisplayLable.Text)) &&
                      (TxtRowNum <= height) && i == (TxtRowNum - 1))
                {
                    for (int x = 0; x < height; x++)
                    {
                        char[] TxtChars = TXtBx_DisplayLable.Text.ToCharArray();
                        if (x < TxtChars.Length)
                        {
                            rows[x] = TxtChars[x].ToString();
                        }
                        else
                        {
                            rows[x] = "X";
                        }

                    }
                }

                rowString = string.Join(" ", rows.ToArray());
                SquarePattern.Add(rowString);
            }

            #endregion


            Div_Options.Visible = false;
            Btn_Redraw.Visible = true;
            Btn_Draw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            return SquarePattern;
        }

        /// <summary>
        /// Method calling the method on the WCF service to generate Rectangle Pattern.
        /// This method also makes sure only the relevent data is displayed
        /// </summary>
        /// <returns>A List<string> which acts a datasource to the Gridview to display shape</string></returns>
        private List<string> GenerateRectangle()
        {
            int height = int.Parse(TxtBx_Height.Text);
            int length = (2 * height - 1);
            int TxtRowNum = 0;
            string rowString = "";

            List<string> SquarePattern = new List<string>();

            if (!string.IsNullOrEmpty(TxtBx_rowNum.Text))
            {
                TxtRowNum = int.Parse(TxtBx_rowNum.Text);
            }

            //ASCIShapeServiceReference1.ASCIService1Client client = new ASCIShapeServiceReference1.ASCIService1Client();
            //SquarePattern = client.GenerateRectangle(height, TXtBx_DisplayLable.Text, TxtRowNum).ToList();

            #region Generate Rectangle

            for (int i = 0; i < height; i++)
            {
                List<string> rows = new List<string>();
                for (int j = 0; j < length; j++)
                {
                    rows.Add("X");
                }

                //Inserting Text into the pattern
                if ((!string.IsNullOrEmpty(TXtBx_DisplayLable.Text)) &&
                      (TxtRowNum <= length) && i == (TxtRowNum - 1))
                {
                    for (int x = 0; x < height; x++)
                    {
                        char[] TxtChars = TXtBx_DisplayLable.Text.ToCharArray();
                        if (x < TxtChars.Length)
                        {
                            rows[x] = TxtChars[x].ToString();
                        }
                        else
                        {
                            rows[x] = "X";
                        }

                    }
                }

                rowString = string.Join(" ", rows.ToArray());
                SquarePattern.Add(rowString);
            }

            #endregion

            
            Div_Options.Visible = false;
            Btn_Redraw.Visible = true;
            Btn_Draw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            return SquarePattern;

        }

        /// <summary>
        /// Method calling the method on the WCF service to generate Triangle shape.
        /// This method also makes sure only the relevent data is displayed
        /// </summary>
        /// <returns>A List<string> which acts a datasource to the Gridview to display shape</string></returns>
        private List<string> GenerateTriangle()
        {
            int Height = int.Parse(TxtBx_Height.Text);
            int length = (2 * Height) - 1;
            int width = Height;
            int maxCharaCount = Height - 1;
            int TxtRowNum = 0;
            string newString = "";
            int tempVal = 0;

            List<string> TrianglePattern = new List<string>();

            if (!string.IsNullOrEmpty(TxtBx_rowNum.Text))
            {
                TxtRowNum = int.Parse(TxtBx_rowNum.Text);
            }

            //ASCIShapeServiceReference1.ASCIService1Client client = new ASCIShapeServiceReference1.ASCIService1Client();
            //TrianglePattern = client.GenerateTriangle(Height, TXtBx_DisplayLable.Text, TxtRowNum).ToList();

            #region Generate Triangle

            for (int rowCount = 0; rowCount < width; rowCount++)
            {
                List<string> rows = new List<string>();
                List<int> columnNums = new List<int>();
                tempVal = rowCount;

                while (tempVal >= 0)
                {
                    columnNums.Add(tempVal);
                    tempVal = tempVal - 2;
                }

                for (int columnCount = 0; columnCount < length; columnCount++)
                {
                    rows.Add("-");
                }

                foreach (int item in columnNums)
                {
                    rows[maxCharaCount - item] = "X";
                    rows[maxCharaCount + item] = "X";

                    //Inserting the Text into the pattern
                    if (rowCount == TxtRowNum - 1)
                    {
                        char[] displayAry = TXtBx_DisplayLable.Text.ToCharArray();
                        for (int i = 0; i < length; i++)
                        {
                            if (i < displayAry.Length && (i + 1) < displayAry.Length)
                            {
                                rows[maxCharaCount - item] = displayAry[i].ToString();
                                rows[maxCharaCount + item] = displayAry[i + 1].ToString();
                            }
                        }
                    }
                }

                newString = string.Join(" ", rows.ToArray());
                TrianglePattern.Add(newString);
            }

            #endregion


            Div_Options.Visible = false;
            Btn_Redraw.Visible = true;
            Btn_Draw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            return TrianglePattern;
        }

        /// <summary>
        /// Method calling the method on the WCF service to generate Diamond-1 shape.
        /// This method also makes sure only the relevent data is displayed
        /// </summary>
        /// <returns>A List<string> which acts a datasource to the Gridview to display shape</string></returns>
        private List<string> GenerateDiamond1()
        {
            int Height = int.Parse(TxtBx_Height.Text);
            int length = (2 * Height) - 1;
            int baseCharaCount = Height - 1;
            int TxtRowNum = 0;
            int tempVal = 0;
            string newString = "";

            List<string> DiamondPattern = new List<string>();

            if (!string.IsNullOrEmpty(TxtBx_rowNum.Text))
            {
                TxtRowNum = int.Parse(TxtBx_rowNum.Text);
            }
            List<string> ReversePattern = new List<string>();

            //ASCIShapeServiceReference1.ASCIService1Client client = new ASCIShapeServiceReference1.ASCIService1Client();
            //DiamondPattern = client.GenerateDiamond1(Height, TXtBx_DisplayLable.Text, TxtRowNum).ToList();

            #region Upper Triangle in Diamond

            for (int rowCount = 0; rowCount < Height; rowCount++)
            {
                List<string> rows = new List<string>();
                List<int> columnNums = new List<int>();
                tempVal = rowCount;

                while (tempVal >= 0)
                {
                    columnNums.Add(tempVal);
                    tempVal = tempVal - 2;
                }

                for (int columnCount = 0; columnCount < length; columnCount++)
                {
                    rows.Add("-");
                }

                foreach (int item in columnNums)
                {
                    if (item == 0)
                    {
                        rows[baseCharaCount - item] = "X";
                    }
                    else
                    {
                        rows[baseCharaCount - item] = "X";
                        rows[baseCharaCount + item] = "X";
                    }
                }

                newString = string.Join(" ", rows.ToArray());
                DiamondPattern.Add(newString);
            }

            #endregion

            #region Lower Triangle in Diamond

            ReversePattern = DiamondPattern.ToList();
            ReversePattern.Reverse();
            ReversePattern.RemoveAt(0);
            DiamondPattern.AddRange(ReversePattern);           

            #endregion

            //Inserting the Text into the pattern
            if (TxtRowNum < DiamondPattern.Count)
            {
                DiamondPattern[TxtRowNum - 1] = DiamondPattern[TxtRowNum - 1].Replace('X', TXtBx_DisplayLable.Text[0]);
            }


            Div_Options.Visible = false;
            Btn_Redraw.Visible = true;
            Btn_Draw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            return DiamondPattern;
        }

        /// <summary>
        /// Method calling the method on the WCF service to generate Diamond-2 Pattern.
        /// This method also makes sure only the relevent data is displayed
        /// </summary>
        /// <returns>A List<string> which acts a datasource to the Gridview to display shape</string></returns>
        private List<string> GenerateDiamond2()
        {
            int Height = int.Parse(TxtBx_Height.Text);
            int baseCharaCount = (int)Height / 2;
            int offSet = baseCharaCount;
            int TxtRowNum = 0;
            int count = 0;
            string newString = "";

            List<string> TrianglePattern = new List<string>();

            if (!string.IsNullOrEmpty(TxtBx_rowNum.Text))
            {
                TxtRowNum = int.Parse(TxtBx_rowNum.Text);
            }

            //ASCIShapeServiceReference1.ASCIService1Client client = new ASCIShapeServiceReference1.ASCIService1Client();
            //TrianglePattern = client.GenerateDiamond2(Height, TXtBx_DisplayLable.Text, TxtRowNum).ToList();

            #region Diamond 2 code

            for (int rowCount = 0; rowCount < Height; rowCount++)
            {
                List<string> rows = new List<string>();
                count = baseCharaCount;

                for (int columnCount = 0; columnCount < Height; columnCount++)
                {
                    rows.Add("X");
                }

                if (rowCount < baseCharaCount && rowCount != baseCharaCount)
                {
                    for (int i = 0; i < offSet; i++)
                    {
                        rows[baseCharaCount - count] = "-";
                        rows[baseCharaCount + count] = "-";
                        count--;
                    }
                    offSet--;
                }
                else
                {
                    count = baseCharaCount;
                    for (int i = 0; i < offSet; i++)
                    {
                        rows[baseCharaCount - count] = "-";
                        rows[baseCharaCount + count] = "-";
                        count--;
                    }
                    offSet++;
                }

                newString = string.Join(" ", rows.ToArray());

                //Inserting the Text into the pattern
                if (rowCount == TxtRowNum - 1)
                {
                    newString = newString.Replace('X', TXtBx_DisplayLable.Text[0]);
                }


                TrianglePattern.Add(newString);
            }

            #endregion


            Div_Options.Visible = false;
            Btn_Redraw.Visible = true;
            Btn_Draw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            return TrianglePattern;
        }

        /// <summary>
        /// Redraw button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Redraw_Click(object sender, EventArgs e)
        {
            Div_Options.Visible = true;
            Div_ShapeTextArea.Visible = false;
            Btn_Draw.Visible = true;
            Btn_Redraw.Visible = false;
            lbl_Diamond2Err.Visible = false;
            Lbl_PageErr.Visible = false;

            UpdateHistory();
        }

        protected void TxtBx_rowNum_TextChanged(object sender, EventArgs e)
        {
        }

        protected void TxtBx_Height_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Clear Button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_ClearHistory_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\Public\ASCIShapeGeneratorHistory.txt";

                if (File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }

                UpdateHistory();
            }
            catch (Exception ex)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// User History Txt click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BList_userHistory_Click(object sender, BulletedListEventArgs e)
        {
            try
            {
                string previousShape = BList_userHistory.Items[e.Index].Text;
                string[] delimiters = { "Shape:", "," };
                string[] previousShapeAry = previousShape.Split(delimiters, StringSplitOptions.None);
                previousShapeAry[1].Trim();
                GenerateShape(previousShapeAry[1]);
            }
            catch (Exception e1)
            {
                Lbl_PageErr.Visible = true;
                Lbl_PageErr.Text = e1.ToString();
                throw;
            }
        }
    }
}
