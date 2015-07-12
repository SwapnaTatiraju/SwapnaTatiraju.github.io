using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ADCIShapeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.

    public class ASCIShapeService1 : IASCIService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<string> GenerateSquare(int height, string TxtToDisplay, int TxtRowNum)
        {
            string rowString = "";
            List<string> SquarePattern = new List<string>();

            for (int i = 0; i < height; i++)
            {
                List<string> rows = new List<string>();
                for (int j = 0; j < height; j++)
                {
                    rows.Add("X");
                }

                if (TxtRowNum > 0 && (!string.IsNullOrEmpty(TxtToDisplay)) &&
                      (TxtRowNum <= height) && i == (TxtRowNum - 1))
                {
                    for (int x = 0; x < height; x++)
                    {
                        char[] TxtChars = TxtToDisplay.ToCharArray();
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

            return SquarePattern;
        }

        public List<string> GenerateRectangle(int height, string TxtToDisplay, int TxtRowNum)
        {
            string rowString = "";
            int length = (2 * height - 1);
            List<string> SquarePattern = new List<string>();

            for (int i = 0; i < height; i++)
            {
                List<string> rows = new List<string>();
                for (int j = 0; j < length; j++)
                {
                    rows.Add("X");
                }

                //Inserting Text into the pattern
                if (TxtRowNum > 0 && (!string.IsNullOrEmpty(TxtToDisplay)) &&
                      (TxtRowNum <= length) && i == (TxtRowNum - 1))
                {
                    for (int x = 0; x < height; x++)
                    {
                        char[] TxtChars = TxtToDisplay.ToCharArray();
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

            return SquarePattern;
        }

        public List<string> GenerateTriangle(int height, string TxtToDisplay, int TxtRowNum)
        {
            string newString = "";
            
            List<string> TrianglePattern = new List<string>();

            int length = (2 * height) - 1;
            int width = height;
            int maxCharaCount = height - 1;
            int tempVal = 0;

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
                        char[] displayAry = TxtToDisplay.ToCharArray();
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
            return TrianglePattern;
        }

        public List<string> GenerateDiamond1(int height, string TxtToDisplay, int TxtRowNum)
        {
            List<string> Diamond1Pattern = new List<string>();
            List<string> ReversePattern = new List<string>();

            int length = (2 * height) - 1;
            int baseCharaCount = height - 1;
            string newString;
            int tempVal = 0;

            #region Upper Triangle in Diamond

            for (int rowCount = 0; rowCount < height; rowCount++)
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
                Diamond1Pattern.Add(newString);
            }

            #endregion

            #region Lower Triangle in Diamond

            ReversePattern = Diamond1Pattern.ToList();
            ReversePattern.Reverse();
            ReversePattern.RemoveAt(0);
            Diamond1Pattern.AddRange(ReversePattern);

            #endregion

            //Inserting the Text into the pattern
            if (TxtRowNum > 0 && TxtRowNum < Diamond1Pattern.Count)
            {
                Diamond1Pattern[TxtRowNum - 1] = Diamond1Pattern[TxtRowNum - 1].Replace('X', TxtToDisplay[0]);
            }

            return Diamond1Pattern;
        }

        public List<string> GenerateDiamond2(int height, string TxtToDisplay, int TxtRowNum)
        {
            List<string> Diamond2Pattern = new List<string>();

            int baseCharaCount = (int)height / 2;
            int offSet = baseCharaCount;
            string newString;
            int count = 0;

            for (int rowCount = 0; rowCount < height; rowCount++)
            {
                List<string> rows = new List<string>();
                count = baseCharaCount;

                for (int columnCount = 0; columnCount < height; columnCount++)
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
                    newString = newString.Replace('X', TxtToDisplay[0]);
                }


                Diamond2Pattern.Add(newString);
            }

            return Diamond2Pattern;
        }

        public void SaveHistoryToFile(string Shape, int height, string TxtToDisplay, int TxtRowNum)
        { 

        }

    }
}
