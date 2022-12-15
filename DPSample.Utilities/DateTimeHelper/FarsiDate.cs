namespace DPSample.Utilities.DateTimeHelper
{
    public class FarsiDate
    {
        private System.Globalization.PersianCalendar pcMydate;

        private int intYear;

        private int intMonth;

        private int intDay;

        private FarsiDate.perDayWeek intDayOfWeek;

        private string[] strDayName;

        private string[] strMonthName;

        private string[] strDayDateName;

        private string strFormat;

        private char chrSeparator;

        private int _Day
        {
            set
            {
                this.intDay = value;
            }
        }

        private FarsiDate.perDayWeek _DayWeek
        {
            set
            {
                this.intDayOfWeek = value;
            }
        }

        private int _Month
        {
            set
            {
                this.intMonth = value;
            }
        }

        private int _Year
        {
            set
            {
                this.intYear = value;
            }
        }

        public int Day
        {
            get
            {
                int num = this.intDay;
                return num;
            }
        }

        public string dayDateName
        {
            get
            {
                string str = this.strDayDateName[this.Day - 1];
                return str;
            }
        }

        public string DayName
        {
            get
            {
                int num = 0;
                FarsiDate.perDayWeek _perDayWeek = this.intDayOfWeek;
                switch (_perDayWeek)
                {
                    case FarsiDate.perDayWeek.یکشنبـه:
                        {
                            num = 1;
                            break;
                        }
                    case FarsiDate.perDayWeek.دوشنبه:
                        {
                            num = 2;
                            break;
                        }
                    case FarsiDate.perDayWeek.سه_شنبه:
                        {
                            num = 3;
                            break;
                        }
                    case FarsiDate.perDayWeek.چهارشنبه:
                        {
                            num = 4;
                            break;
                        }
                    case FarsiDate.perDayWeek.پنجشنبه:
                        {
                            num = 5;
                            break;
                        }
                    case FarsiDate.perDayWeek.جمعـه:
                        {
                            num = 6;
                            break;
                        }
                    case FarsiDate.perDayWeek.شنبه:
                        {
                            num = 0;
                            break;
                        }
                }
                string str = this.strDayName[num];
                return str;
            }
        }

        public FarsiDate.perDayWeek DayWeek
        {
            get
            {
                FarsiDate.perDayWeek _perDayWeek = this.intDayOfWeek;
                return _perDayWeek;
            }
        }

        public string displyFormat
        {
            get
            {
                string str = this.strFormat;
                return str;
            }
            set
            {
                this.strFormat = value;
            }
        }

        public int Month
        {
            get
            {
                int num = this.intMonth;
                return num;
            }
        }

        public string MonthName
        {
            get
            {
                string str = this.strMonthName[this.Month - 1];
                return str;
            }
        }

        public char separatorChar
        {
            get
            {
                char chr = this.chrSeparator;
                return chr;
            }
            set
            {
                this.chrSeparator = value;
            }
        }

        public int Year
        {
            get
            {
                int num = this.intYear;
                return num;
            }
        }

        public string YearFarsi
        {
            get
            {
                string str = this.toNumber((double)this.Year);
                return str;
            }
        }

        public FarsiDate()
        {
            this.pcMydate = new System.Globalization.PersianCalendar();
            this.intYear = 0;
            this.intMonth = 0;
            this.intDay = 0;
            this.intDayOfWeek = FarsiDate.perDayWeek.شنبه;
            string[] strArrays = new string[7];
            strArrays[0] = "شنبه";
            strArrays[1] = "یکشنبه";
            strArrays[2] = "دوشنبه";
            strArrays[3] = "سه شنبه";
            strArrays[4] = "چهار شنبه";
            strArrays[5] = "پنجشنبه";
            strArrays[6] = "جمعه";
            this.strDayName = strArrays;
            strArrays = new string[12];
            strArrays[0] = "فرودرین";
            strArrays[1] = "اردیبهشت";
            strArrays[2] = "خرداد";
            strArrays[3] = "تیر";
            strArrays[4] = "مرداد";
            strArrays[5] = "شهریور";
            strArrays[6] = "مهر";
            strArrays[7] = "آبان";
            strArrays[8] = "آذر";
            strArrays[9] = "دی";
            strArrays[10] = "بهمن";
            strArrays[11] = "اسفند";
            this.strMonthName = strArrays;
            strArrays = new string[31];
            strArrays[0] = "یکم";
            strArrays[1] = "دوم";
            strArrays[2] = "سوم";
            strArrays[3] = "چهارم";
            strArrays[4] = "پنجم";
            strArrays[5] = "ششم";
            strArrays[6] = "هفتم";
            strArrays[7] = "هشتم";
            strArrays[8] = "نهم";
            strArrays[9] = "دهم";
            strArrays[10] = "یازدهم";
            strArrays[11] = "دوازدهم";
            strArrays[12] = "سیزدهم";
            strArrays[13] = "چهاردهم";
            strArrays[14] = "پانزدهم";
            strArrays[15] = "شانزدهم";
            strArrays[16] = "هفدهم";
            strArrays[17] = "هجدهم";
            strArrays[18] = "نونزدهم";
            strArrays[19] = "بیستم";
            strArrays[20] = "بیست و یکم";
            strArrays[21] = "بیست و دوم";
            strArrays[22] = "بیست و سوم";
            strArrays[23] = "بیست و چهارم";
            strArrays[24] = "بیست و پنجم ";
            strArrays[25] = "بیست و ششم";
            strArrays[26] = "بیست و هفتم";
            strArrays[27] = "بیست و هشتم";
            strArrays[28] = "بیست و نهم";
            strArrays[29] = "سی ام";
            strArrays[30] = "سی و یکم";
            this.strDayDateName = strArrays;
            this.strFormat = "YYYY;/;mm;/;dd";
            this.chrSeparator = '/';
            this.getPersianDate();
        }


        public string fulDate(string strDate)
        {
            bool flag;
            char[] chrArray = new char[1];
            chrArray[0] = this.separatorChar;
            string[] strArrays = strDate.Split(chrArray);
            bool length = (int)strArrays.Length >= 2;
            if (length)
            {
                if (string.IsNullOrEmpty(strArrays[0]) || string.IsNullOrEmpty(strArrays[1]))
                {
                    flag = false;
                }
                else
                {
                    flag = !string.IsNullOrEmpty(strArrays[2]);
                }
                length = flag;
                if (length)
                {
                    int fourDigitYear = int.Parse(strArrays[0]);
                    int num = int.Parse(strArrays[1]);
                    int num1 = int.Parse(strArrays[2]);
                    string str = num.ToString();
                    string str1 = num1.ToString();
                    fourDigitYear = this.pcMydate.ToFourDigitYear(fourDigitYear);
                    length = num >= 10;
                    if (!length)
                    {
                        str = string.Concat("0", num.ToString());
                    }
                    length = num1 >= 10;
                    if (!length)
                    {
                        str1 = string.Concat("0", num1.ToString());
                    }
                    object[] objArray = new object[5];
                    objArray[0] = fourDigitYear.ToString();
                    objArray[1] = this.separatorChar;
                    objArray[2] = str;
                    objArray[3] = this.separatorChar;
                    objArray[4] = str1;
                    string str2 = string.Concat(objArray);
                    return str2;
                }
                else
                {
                    throw new Exception("تاریخ وارد شده معتبر نیست");
                }
            }
            else
            {
                throw new Exception("تاریخ وارد شده معتبر نیست");
            }
        }

        private string fulDate(int iYear, int iMonth, int iDay, FarsiDate.perDayWeek iDayOfWeek)
        {
            int num = 0;
            string str;
            int year;
            string str1 = iMonth.ToString();
            string str2 = iDay.ToString();
            string str3 = "";
            iYear = this.pcMydate.ToFourDigitYear(iYear);
            bool length = iMonth >= 10;
            if (!length)
            {
                str1 = string.Concat("0", iMonth.ToString());
            }
            length = iDay >= 10;
            if (!length)
            {
                str2 = string.Concat("0", iDay.ToString());
            }
            this._Year = iYear;
            this._Month = iMonth;
            this._Day = iDay;
            this._DayWeek = iDayOfWeek;
            char[] chrArray = new char[1];
            chrArray[0] = ';';
            string[] strArrays = this.displyFormat.Split(chrArray);
            length = (int)strArrays.Length != 0;
            if (length)
            {
                string[] strArrays1 = strArrays;

                while (true)
                {
                    length = num < (int)strArrays1.Length;
                    if (!length)
                    {
                        break;
                    }
                    str = strArrays1[num];
                    string str4 = str;
                    if (str4 != null)
                    {
                        if (str4 == "yy" || str4 == "YY")
                        {
                            year = this.Year;
                            str3 = string.Concat(str3, year.ToString());
                            goto Label1;
                        }
                        else if (str4 == "yyyy" || str4 == "YYYY")
                        {
                            str3 = string.Concat(str3, " ", this.toNumber((double)this.Year), " ");
                            goto Label1;
                        }
                        else if (str4 == "MM")
                        {
                            str3 = string.Concat(str3, " ", this.MonthName, " ");
                            goto Label1;
                        }
                        else if (str4 == "mm")
                        {
                            year = this.Month;
                            str3 = string.Concat(str3, year.ToString());
                            goto Label1;
                        }
                        else if (str4 == "dn")
                        {
                            str3 = string.Concat(str3, " ", this.DayName, " ");
                            goto Label1;
                        }
                        else if (str4 == "dd")
                        {
                            year = this.Day;
                            str3 = string.Concat(str3, year.ToString());
                            goto Label1;
                        }
                        else if (str4 == "DD")
                        {
                            str3 = string.Concat(str3, " ", this.dayDateName, " ");
                            goto Label1;
                        }
                        else if (str4 == "/")
                        {
                            str3 = string.Concat(str3, this.chrSeparator);
                            goto Label1;
                        }
                        str3 = string.Concat(str3, " ", str, " ");
                        goto Label1;
                    }
                    else
                    {
                        str3 = string.Concat(str3, " ", str, " ");
                        goto Label1;
                    }
                Label1:
                    num++;
                }
                string str5 = str3;
                return str5;
            }
            else
            {
                throw new Exception("نحوه نمایش تاریخ مشخص نشده است");
            }

        }

        public string getPersianDate()
        {
            string str = this.fulDate(this.pcMydate.GetYear(DateTime.Now), this.pcMydate.GetMonth(DateTime.Now), this.pcMydate.GetDayOfMonth(DateTime.Now), (FarsiDate.perDayWeek)this.pcMydate.GetDayOfWeek(DateTime.Now));
            return str;
        }

        public string getPersianDate(DateTime miladiDate)
        {
            bool flag = this.isValidMiladeDate(miladiDate);
            if (flag)
            {
                string str = this.fulDate(this.pcMydate.GetYear(miladiDate), this.pcMydate.GetMonth(miladiDate), this.pcMydate.GetDayOfMonth(miladiDate), (FarsiDate.perDayWeek)this.pcMydate.GetDayOfWeek(miladiDate));
                return str;
            }
            else
            {
                throw new Exception("تاریخ میلادی وارد شده معتبر نیست");
            }
        }

        public string getPersianDate(string strMiladiDate)
        {
            bool flag = this.isValidMiladeDate(strMiladiDate);
            if (flag)
            {
                DateTime dateTime = DateTime.Parse(strMiladiDate);
                string str = this.fulDate(this.pcMydate.GetYear(dateTime), this.pcMydate.GetMonth(dateTime), this.pcMydate.GetDayOfMonth(dateTime), (FarsiDate.perDayWeek)this.pcMydate.GetDayOfWeek(dateTime));
                return str;
            }
            else
            {
                throw new Exception("تاریخ میلادی وارد شده معتبر نیست");
            }
        }

        public string getPersianDate(int iYear, int iMonth, int iDay)
        {
            bool flag = this.isValidMiladeDate(iYear, iMonth, iDay);
            if (flag)
            {
                object[] objArray = new object[5];
                objArray[0] = iYear;
                objArray[1] = "/";
                objArray[2] = iMonth;
                objArray[3] = "/";
                objArray[4] = iDay;
                DateTime dateTime = DateTime.Parse(string.Concat(objArray));
                string str = this.fulDate(this.pcMydate.GetYear(dateTime), this.pcMydate.GetMonth(dateTime), this.pcMydate.GetDayOfMonth(dateTime), (FarsiDate.perDayWeek)this.pcMydate.GetDayOfWeek(dateTime));
                return str;
            }
            else
            {
                throw new Exception("تاریخ میلادی وارد شده معتبر نیست");
            }
        }

        public bool isfulDate(string strDate)
        {
            bool flag;
            bool flag1;
            bool length;
            char[] chrArray = new char[1];
            chrArray[0] = this.separatorChar;
            string[] strArrays = strDate.Split(chrArray);
            bool length1 = (int)strArrays.Length >= 2;
            if (length1)
            {
                if (string.IsNullOrEmpty(strArrays[0]) || string.IsNullOrEmpty(strArrays[1]))
                {
                    flag1 = false;
                }
                else
                {
                    flag1 = !string.IsNullOrEmpty(strArrays[2]);
                }
                length1 = flag1;
                if (length1)
                {
                    string str = strArrays[0];
                    string str1 = strArrays[1];
                    if (str.Length < 4 || str1.Length < 2)
                    {
                        length = false;
                    }
                    else
                    {
                        length = strDate.Length >= 2;
                    }
                    length1 = length;
                    if (length1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    return flag;
                }
                else
                {
                    throw new Exception("تاریخ وارد شده معتبر نیست");
                }
            }
            else
            {
                throw new Exception("تاریخ وارد شده معتبر نیست");
            }
        }

        public bool isValidDete(string strDate)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool length = this.isfulDate(strDate);
            if (!length)
            {
                strDate = this.fulDate(strDate);
            }
            length = strDate.Length >= 10;
            if (length)
            {
                int num = int.Parse(strDate.Substring(0, 4));
                int num1 = int.Parse(strDate.Substring(5, 2));
                int num2 = int.Parse(strDate.Substring(8, 2));
                if (num < 0 || num1 > 12 || num1 < 0 || num2 < 0)
                {
                    flag1 = false;
                }
                else
                {
                    flag1 = num2 <= 31;
                }
                length = flag1;
                if (length)
                {
                    if (num1 > 6)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = num2 <= 31;
                    }
                    length = flag2;
                    if (length)
                    {
                        if (num1 < 7)
                        {
                            flag3 = true;
                        }
                        else
                        {
                            flag3 = num2 <= 30;
                        }
                        length = flag3;
                        if (length)
                        {
                            if (num1 != 12)
                            {
                                flag4 = true;
                            }
                            else
                            {
                                flag4 = num2 <= 29;
                            }
                            length = flag4;
                            if (!length)
                            {
                                length = this.pcMydate.IsLeapYear(num);
                                if (length)
                                {
                                    length = num2 <= 30;
                                    if (length)
                                    {
                                        goto Label1;
                                    }
                                    flag = false;
                                    return flag;
                                }
                                else
                                {
                                    flag = false;
                                    return flag;
                                }
                            }
                        Label1:
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
            else
            {
                throw new Exception("تاریخ وارد شده معتبر نیست");
            }
        }

        private bool isValidMiladeDate(DateTime miladiDate)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            int year = miladiDate.Year;
            int month = miladiDate.Month;
            int day = miladiDate.Day;
            if (year < 0 || month < 0 || month > 12 || day < 0)
            {
                flag1 = false;
            }
            else
            {
                flag1 = day <= 31;
            }
            bool flag4 = flag1;
            if (flag4)
            {
                flag4 = !DateTime.IsLeapYear(year);
                if (flag4)
                {
                    if (month != 2)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = day <= 28;
                    }
                    flag4 = flag2;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                else
                {
                    if (month != 2)
                    {
                        flag3 = true;
                    }
                    else
                    {
                        flag3 = day <= 29;
                    }
                    flag4 = flag3;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                int num = month;
                switch (num)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        {
                            flag4 = day <= 31;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    case 2:
                    case 6:
                        {
                        Label3:
                            flag = true;
                            break;
                        }
                    case 4:
                    case 9:
                    case 11:
                        {
                            flag4 = day <= 30;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    default:
                        {
                            flag = true;
                            break;
                        }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        private bool isValidMiladeDate(string miladiDate)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            int num = int.Parse(miladiDate.Substring(1, 4));
            int num1 = int.Parse(miladiDate.Substring(6, 2));
            int num2 = int.Parse(miladiDate.Substring(9, 2));
            if (num < 0 || num1 < 0 || num1 > 12 || num2 < 0)
            {
                flag1 = false;
            }
            else
            {
                flag1 = num2 <= 31;
            }
            bool flag4 = flag1;
            if (flag4)
            {
                flag4 = !DateTime.IsLeapYear(num);
                if (flag4)
                {
                    if (num1 != 2)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = num2 <= 28;
                    }
                    flag4 = flag2;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                else
                {
                    if (num1 != 2)
                    {
                        flag3 = true;
                    }
                    else
                    {
                        flag3 = num2 <= 29;
                    }
                    flag4 = flag3;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                int num3 = num1;
                switch (num3)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        {
                            flag4 = num2 <= 31;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    case 2:
                    case 6:
                        {
                        Label3:
                            flag = true;
                            break;
                        }
                    case 4:
                    case 9:
                    case 11:
                        {
                            flag4 = num2 <= 30;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    default:
                        {
                            flag = true;
                            break;
                        }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        private bool isValidMiladeDate(int iYear, int iMonth, int iDay)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            if (iYear < 0 || iMonth < 0 || iMonth > 12 || iDay < 0)
            {
                flag1 = false;
            }
            else
            {
                flag1 = iDay <= 31;
            }
            bool flag4 = flag1;
            if (flag4)
            {
                flag4 = !DateTime.IsLeapYear(iYear);
                if (flag4)
                {
                    if (iMonth != 2)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag2 = iDay <= 28;
                    }
                    flag4 = flag2;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                else
                {
                    if (iMonth != 2)
                    {
                        flag3 = true;
                    }
                    else
                    {
                        flag3 = iDay <= 29;
                    }
                    flag4 = flag3;
                    if (!flag4)
                    {
                        flag = false;
                        return flag;
                    }
                }
                int num = iMonth;
                switch (num)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        {
                            flag4 = iDay <= 31;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    case 2:
                    case 6:
                        {
                        Label3:
                            flag = true;
                            break;
                        }
                    case 4:
                    case 9:
                    case 11:
                        {
                            flag4 = iDay <= 30;
                            if (flag4)
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    default:
                        {
                            flag = true;
                            break;
                        }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static string RevrseDate(string strDate)
        {
            bool flag = string.IsNullOrEmpty(strDate);
            if (flag)
            {
                throw new Exception("هیچ تاریخی وارد نشده است");
            }
            else
            {
                string str = strDate.Substring(0, 4);
                string str1 = strDate.Substring(5, 2);
                string str2 = strDate.Substring(8, 2);
                string[] strArrays = new string[5];
                strArrays[0] = str2;
                strArrays[1] = "/";
                strArrays[2] = str1;
                strArrays[3] = "/";
                strArrays[4] = str;
                string str3 = string.Concat(strArrays);
                return str3;
            }
        }

        public static string RevrseDate(object objDate)
        {
            string str = FarsiDate.RevrseDate(objDate.ToString());
            return str;
        }

        public string showInDisplyFormat(string strDate)
        {
            int num2 = 0;
            int month;
            string str;
            bool flag;
            string str1 = "";
            char[] chrArray = new char[1];
            chrArray[0] = this.separatorChar;
            string[] strArrays = strDate.Split(chrArray);
            bool length = (int)strArrays.Length >= 2;
            if (length)
            {
                if (string.IsNullOrEmpty(strArrays[0]) || string.IsNullOrEmpty(strArrays[1]))
                {
                    flag = false;
                }
                else
                {
                    flag = !string.IsNullOrEmpty(strArrays[2]);
                }
                length = flag;
                if (length)
                {
                    int fourDigitYear = int.Parse(strArrays[0]);
                    int num = int.Parse(strArrays[1]);
                    int num1 = int.Parse(strArrays[2]);
                    string str2 = num.ToString();
                    string str3 = num1.ToString();
                    fourDigitYear = this.pcMydate.ToFourDigitYear(fourDigitYear);
                    length = num >= 10;
                    if (!length)
                    {
                        str2 = string.Concat("0", num.ToString());
                    }
                    length = num1 >= 10;
                    if (!length)
                    {
                        str3 = string.Concat("0", num1.ToString());
                    }
                    chrArray = new char[1];
                    chrArray[0] = ';';
                    string[] strArrays1 = this.displyFormat.Split(chrArray);
                    length = (int)strArrays1.Length != 0;

                    if (length)
                    {
                        string[] strArrays2 = strArrays1;

                        while (true)
                        {
                            length = num2 < (int)strArrays2.Length;
                            if (!length)
                            {
                                break;
                            }
                            str = strArrays2[num2];
                            string str4 = str;
                            if (str4 != null)
                            {
                                if (str4 == "yy" || str4 == "YY")
                                {
                                    str1 = string.Concat(str1, fourDigitYear.ToString());
                                    goto Label1;
                                }
                                else if (str4 == "yyyy" || str4 == "YYYY")
                                {
                                    str1 = string.Concat(str1, " ", this.toNumber((double)fourDigitYear), " ");
                                    goto Label1;
                                }
                                else if (str4 == "MM")
                                {
                                    month = this.Month;
                                    this._Month = num;
                                    str1 = string.Concat(str1, " ", this.MonthName, " ");
                                    this._Month = num;
                                    goto Label1;
                                }
                                else if (str4 == "mm")
                                {
                                    str1 = string.Concat(str1, str2);
                                    goto Label1;
                                }
                                else if (str4 == "dn")
                                {
                                    month = this.Day;
                                    this._Day = num1;
                                    str1 = string.Concat(str1, " ", this.DayName, " ");
                                    this._Day = month;
                                    goto Label1;
                                }
                                else if (str4 == "dd")
                                {
                                    str1 = string.Concat(str1, str3);
                                    goto Label1;
                                }
                                else if (str4 == "DD")
                                {
                                    month = this.Day;
                                    this._Day = num1;
                                    str1 = string.Concat(str1, " ", this.dayDateName, " ");
                                    this._Day = month;
                                    goto Label1;
                                }
                                else if (str4 == "/")
                                {
                                    str1 = string.Concat(str1, this.chrSeparator);
                                    goto Label1;
                                }
                                str1 = string.Concat(str1, " ", str, " ");
                                goto Label1;
                            }
                            else
                            {
                                str1 = string.Concat(str1, " ", str, " ");
                                goto Label1;
                            }
                        Label1:
                            num2++;
                        }
                        string str5 = str1;
                        return str5;
                    }
                    else
                    {
                        throw new Exception("نحوه نمایش تاریخ مشخص نشده است");
                    }
                }
                else
                {
                    throw new Exception("تاریخ وارد شده معتبر نیست");
                }
            }
            else
            {
                throw new Exception("تاریخ وارد شده معتبر نیست");
            }
        }

        private string Three(double Number)
        {
            string str;
            string str1 = "";
            int[] numArray = new int[4];
            string str2 = Number.ToString().Trim();
            int length = str2.Length;
            bool number = Number != 0;
            if (number)
            {
                number = Number != 100;
                if (number)
                {
                    number = length != 2;
                    if (!number)
                    {
                        numArray[1] = 0;
                    }
                    number = length != 1;
                    if (!number)
                    {
                        numArray[1] = 0;
                        numArray[2] = 0;
                    }
                    int num = 1;
                    while (true)
                    {
                        number = num <= length;
                        if (!number)
                        {
                            break;
                        }
                        str2 = Number.ToString();
                        str2.Trim();
                        numArray[4 - num] = int.Parse(str2.Substring(length - num, 1));
                        num++;
                    }
                    int num1 = numArray[1];
                    switch (num1)
                    {
                        case 1:
                            {
                                str1 = "يكصد";
                                break;
                            }
                        case 2:
                            {
                                str1 = "دويست";
                                break;
                            }
                        case 3:
                            {
                                str1 = "سيصد";
                                break;
                            }
                        case 4:
                            {
                                str1 = "چهارصد";
                                break;
                            }
                        case 5:
                            {
                                str1 = "پانصد";
                                break;
                            }
                        case 6:
                            {
                                str1 = "ششصد";
                                break;
                            }
                        case 7:
                            {
                                str1 = "هفتصد";
                                break;
                            }
                        case 8:
                            {
                                str1 = "هشتصد";
                                break;
                            }
                        case 9:
                            {
                                str1 = "نهصد";
                                break;
                            }
                    }
                    num1 = numArray[2];
                    switch (num1)
                    {
                        case 1:
                            {
                                num1 = numArray[3];
                                switch (num1)
                                {
                                    case 0:
                                        {
                                            str1 = string.Concat(str1, " و ده");
                                            break;
                                        }
                                    case 1:
                                        {
                                            str1 = string.Concat(str1, " و يازده");
                                            break;
                                        }
                                    case 2:
                                        {
                                            str1 = string.Concat(str1, " و دوازده");
                                            break;
                                        }
                                    case 3:
                                        {
                                            str1 = string.Concat(str1, " و سيزده");
                                            break;
                                        }
                                    case 4:
                                        {
                                            str1 = string.Concat(str1, " و چهارده");
                                            break;
                                        }
                                    case 5:
                                        {
                                            str1 = string.Concat(str1, " و پانزده");
                                            break;
                                        }
                                    case 6:
                                        {
                                            str1 = string.Concat(str1, " و شانزده");
                                            break;
                                        }
                                    case 7:
                                        {
                                            str1 = string.Concat(str1, " و هفده");
                                            break;
                                        }
                                    case 8:
                                        {
                                            str1 = string.Concat(str1, " و هجده");
                                            break;
                                        }
                                    case 9:
                                        {
                                            str1 = string.Concat(str1, " و نوزده");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                str1 = string.Concat(str1, " و بيست");
                                break;
                            }
                        case 3:
                            {
                                str1 = string.Concat(str1, " و سي");
                                break;
                            }
                        case 4:
                            {
                                str1 = string.Concat(str1, " و چهل");
                                break;
                            }
                        case 5:
                            {
                                str1 = string.Concat(str1, " و پنجاه");
                                break;
                            }
                        case 6:
                            {
                                str1 = string.Concat(str1, " و شصت");
                                break;
                            }
                        case 7:
                            {
                                str1 = string.Concat(str1, " و هفتاد");
                                break;
                            }
                        case 8:
                            {
                                str1 = string.Concat(str1, " و هشتاد");
                                break;
                            }
                        case 9:
                            {
                                str1 = string.Concat(str1, " و نود");
                                break;
                            }
                    }
                    number = numArray[2] == 1;
                    if (!number)
                    {
                        num1 = numArray[3];
                        switch (num1)
                        {
                            case 1:
                                {
                                    str1 = string.Concat(str1, " و يك");
                                    break;
                                }
                            case 2:
                                {
                                    str1 = string.Concat(str1, " و دو");
                                    break;
                                }
                            case 3:
                                {
                                    str1 = string.Concat(str1, " و سه");
                                    break;
                                }
                            case 4:
                                {
                                    str1 = string.Concat(str1, " و چهار");
                                    break;
                                }
                            case 5:
                                {
                                    str1 = string.Concat(str1, " و پنج");
                                    break;
                                }
                            case 6:
                                {
                                    str1 = string.Concat(str1, " و شش");
                                    break;
                                }
                            case 7:
                                {
                                    str1 = string.Concat(str1, " و هفت");
                                    break;
                                }
                            case 8:
                                {
                                    str1 = string.Concat(str1, " و هشت");
                                    break;
                                }
                            case 9:
                                {
                                    str1 = string.Concat(str1, " و نه");
                                    break;
                                }
                        }
                    }
                    number = length >= 3;
                    if (!number)
                    {
                        str1 = str1.Substring(3, str1.Length - 3);
                    }
                    str = str1;
                }
                else
                {
                    str = "يكصد";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        private string toNumber(double Number)
        {
            string str;
            bool number = Number != 0;
            if (number)
            {
                double[] numArray = new double[5];
                string str1 = Number.ToString();
                byte length = (byte)str1.Length;
                number = length <= 14;
                if (number)
                {
                    byte num = 0;
                    while (true)
                    {
                        number = num <= 14 - length;
                        if (!number)
                        {
                            break;
                        }
                        str1 = string.Concat("0", str1);
                        num = (byte)(num + 1);
                    }
                    num = 0;
                    while (true)
                    {
                        number = (double)num <= (double)(length / 3) + 0.99;
                        if (!number)
                        {
                            break;
                        }
                        numArray[4 - num] = (double)int.Parse(str1.Substring(3 * (4 - num), 3));
                        num = (byte)(num + 1);
                    }
                    bool flag = false;
                    str1 = "";
                    num = 0;
                    while (true)
                    {
                        number = num <= 4;
                        if (!number)
                        {
                            break;
                        }
                        number = numArray[num] == 0;
                        if (!number)
                        {
                            byte num1 = num;
                            switch (num1)
                            {
                                case 0:
                                    {
                                        str1 = string.Concat(str1, this.Three(numArray[num]), " تريليون");
                                        flag = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        number = !flag;
                                        if (!number)
                                        {
                                            str1 = string.Concat(str1, " و ");
                                        }
                                        str1 = string.Concat(str1, this.Three(numArray[num]), " ميليارد");
                                        flag = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        number = !flag;
                                        if (!number)
                                        {
                                            str1 = string.Concat(str1, " و ");
                                        }
                                        str1 = string.Concat(str1, this.Three(numArray[num]), " ميليون");
                                        flag = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        number = !flag;
                                        if (!number)
                                        {
                                            str1 = string.Concat(str1, " و ");
                                        }
                                        str1 = string.Concat(str1, this.Three(numArray[num]), " هزار");
                                        flag = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        number = !flag;
                                        if (!number)
                                        {
                                            str1 = string.Concat(str1, " و ");
                                        }
                                        str1 = string.Concat(str1, this.Three(numArray[num]));
                                        break;
                                    }
                            }
                        }
                        num = (byte)(num + 1);
                    }
                    str = str1;
                }
                else
                {
                    str = "بسيار بزرگ";
                }
            }
            else
            {
                str = "صفر";
            }
            return str;
        }

        public enum perDayWeek
        {
            یکشنبـه = 0,
            دوشنبه = 1,
            سه_شنبه = 2,
            چهارشنبه = 3,
            پنجشنبه = 4,
            جمعـه = 5,
            شنبه = 6
        }
    }
}