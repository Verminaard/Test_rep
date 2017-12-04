using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace KP.Models
{
    public class DAO_Schedule : DAO
    {
        public Schedule GetScheduleByClass(string num)
        {
            List<Day> days = new List<Day>();
            string status;
            try
            {
                int day_number = 1;
                int j = 0;
                Connect();
                MySqlCommand command = new MySqlCommand("SELECT day, name, subect_number, status FROM Class, Schedule, Subject where Class.id_class = Schedule.id_class AND subject.id_subject = schedule.subject AND class.number = @name ORDER BY day, subect_number;", conn);
                command.Parameters.AddWithValue("@name", num);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(dataTable);
                while (j < dataTable.Rows.Count-1)
                {
                    List<Subject> subjects = new List<Subject>();
                    while (day_number == Int32.Parse(dataTable.Rows[j][0].ToString()))
                    {
                        Subject subject = new Subject(dataTable.Rows[j][1].ToString());
                        subjects.Add(subject);
                        j++;
                        if (j >= dataTable.Rows.Count)
                            break;
                    }
                    days.Add(new Day(subjects));
                    day_number++;
                }
                status = dataTable.Rows[j-1][3].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
            return new Schedule(num, status, days);
        }

        public List<Mark> GetMarksByIdAndDate(int id, DateTime FirstDate, DateTime SecondDate)
        {
            List<Mark> Mark = new List<Mark>();
            try
            {
                Connect();
                MySqlCommand command = new MySqlCommand("SELECT mark, date, name FROM Mark, Subject where mark.id_user = @id and mark.id_subject = subject.id_subject and date between @date1 and @date2;", conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date1", FirstDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@date2", SecondDate.ToString("yyyy-MM-dd"));
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Subject sub = new Subject(dataTable.Rows[i][2].ToString());
                    Mark.Add(new Mark(Int32.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), sub));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
            return Mark;
            }

        public List<Homework> GetHomeworkByIdAndDate(int id, DateTime FirstDate, DateTime SecondDate)
        {
            List<Homework> Homework = new List<Homework>();
            try
            {
                Connect();
                MySqlCommand command = new MySqlCommand("SELECT homework, date, name FROM Homework, Subject where homework.id_user = @id and homework.id_subject = subject.id_subject and date between @date1 and @date2", conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date1", FirstDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@date2", SecondDate.ToString("yyyy-MM-dd"));
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Subject sub = new Subject(dataTable.Rows[i][2].ToString());
                    Homework.Add(new Homework(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString(), sub));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
            return Homework;
            }

        /*
        public bool AddRecord(Rec records)
        {
            bool result = true;
            try
            {
                Connect();
                MySqlCommand command = new MySqlCommand("INSERT INTO test_table (name, number, bool)" + "VALUES (@name, @number, @date)", conn);
                command.Parameters.AddWithValue("@name", records.Title);
                command.Parameters.AddWithValue("@number", records.num);
                command.Parameters.AddWithValue("@date", records.tf);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }


        public bool DeleteRecord(Rec records)
        {
            bool result = true;
            try
            {
                Connect();
                MySqlCommand command = new MySqlCommand("DELETE FROM test_table " + "WHERE Test_id = @id", conn);
                command.Parameters.AddWithValue("@id", records.ID);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }


        public bool EditRecord(Rec records)
        {
            bool result = true;
            try
            {
                Connect();
                MySqlCommand command = new MySqlCommand("UPDATE test_table " + "SET Name = @name, Number = @number, Bool = @date where test_id = @id", conn);
                command.Parameters.AddWithValue("@id", records.ID);
                command.Parameters.AddWithValue("@name", records.Title);
                command.Parameters.AddWithValue("@number", records.num);
                command.Parameters.AddWithValue("@date", records.tf);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        */
    }
}