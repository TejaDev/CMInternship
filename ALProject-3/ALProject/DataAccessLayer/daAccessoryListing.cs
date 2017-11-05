using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ALProject.DataAccessLayer
{
    public class daAccessoryListing
    {

        public daAccessoryListing()
        {
            //Initialize properties
            pTransactionSuccessful = true;
            pErrorMessage = "";
        }

        #region "Properties"
        //These properties are for bubbling up error messages from the Data Tier
        private bool pTransactionSuccessful;
        public bool TransactionSuccessful
        {
            get { return pTransactionSuccessful; }
            set { pTransactionSuccessful = value; }
        }
        private string pErrorMessage;
        public string ErrorMessage
        {
            get { return pErrorMessage; }
        }
        #endregion

        #region "Get Methods"

        public DataTable GetEngineModelModel(string ConnectionString)
        {

            DataTable dtEngineModel = new DataTable("dtEngineModel");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetModel";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtEngineModel = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVetClinic
                        DataRow ErrorRow = dtEngineModel.NewRow();
                        dtEngineModel.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtEngineModel.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtEngineModel.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtEngineModel;
        }

        public DataTable GetSpecModel(string ConnectionString)
        {
            DataTable dtSpec = new DataTable("dtSpec");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetSpec";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtSpec = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVet
                        DataRow ErrorRow = dtSpec.NewRow();
                        dtSpec.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtSpec.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtSpec.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtSpec;
        }

        public DataTable GetCategoryModel(string ConnectionString)
        {
            DataTable dtCategory = new DataTable("dtCategory");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetCategory";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtCategory = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVet
                        DataRow ErrorRow = dtCategory.NewRow();
                        dtCategory.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtCategory.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtCategory.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtCategory;
        }

        public DataTable GetAccessoryModel(string ConnectionString)
        {
            DataTable dtAccessory = new DataTable("dtAccessory");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetAccessory";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtAccessory = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVet
                        DataRow ErrorRow = dtAccessory.NewRow();
                        dtAccessory.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtAccessory.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtAccessory.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtAccessory;
        }

        public DataTable GetPositionModel(string ConnectionString)
        {
            DataTable dtPosition = new DataTable("dtPosition");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetPosition";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtPosition = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVet
                        DataRow ErrorRow = dtPosition.NewRow();
                        dtPosition.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtPosition.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtPosition.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtPosition;
        }

        public DataTable GetStatusModel(string ConnectionString)
        {
            DataTable dtStatus = new DataTable("dtStatus");

            // Create & open a SqlConnection, and dispose of it after we are done
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a command and prepare it for execution by the data tier
                SqlCommand command = new SqlCommand();

                // Associate the connection with the command. There could be more than one connection open.
                command.Connection = connection;

                // Set the command type: sproc, return an entire table, supply SQL string
                command.CommandType = CommandType.StoredProcedure;

                //In this case, the Command Text, meaning the command to be executed by the data tier
                //is the name of the sproc. We know this because the command type is storedprocedure
                //If the type were "Text" we would put the SQL expression here.
                command.CommandText = "GetStatus";

                // Create the DataAdapter & DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();

                    //This try catch block handles errors where the sproc (data tier) does not return a result
                    try
                    {
                        // Fill the DataSet using default values for DataTable names, etc
                        da.Fill(ds);

                        // Extract the first table (and only table) from the dataset
                        dtStatus = ds.Tables[0];
                    }
                    catch (SqlException ReadError)
                    {
                        //If the sproc didn't return a result, put the error message in dtVet
                        DataRow ErrorRow = dtStatus.NewRow();
                        dtStatus.Columns.Add("ErrorMessage");
                        ErrorRow["ErrorMessage"] = ReadError.Message.ToString();
                        dtStatus.Columns.Add("ErrorLineNumber");
                        ErrorRow["ErrorLineNumber"] = ReadError.Message.ToString();
                        dtStatus.Rows.Add(ErrorRow);

                        pTransactionSuccessful = false;
                    }
                }
            }
            return dtStatus;
        }

        #endregion

        //#region "Insert Methods"

        //public void AddVetClinic(string ClinicName, string ClinicAddress, string ClinicCity, string ClinicState, string ClinicZip, string ClinicPhoneNumber, string ConnectionString)
        //{
        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "AddVetClinic";

        //        command.Parameters.Add("@ClinicName", SqlDbType.VarChar).Value = ClinicName;
        //        command.Parameters["@ClinicName"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicAddress", SqlDbType.VarChar).Value = ClinicAddress;
        //        command.Parameters["@ClinicAddress"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicCity", SqlDbType.VarChar).Value = ClinicCity;
        //        command.Parameters["@ClinicCity"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicState", SqlDbType.VarChar).Value = ClinicState;
        //        command.Parameters["@ClinicState"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicZip", SqlDbType.VarChar).Value = ClinicZip;
        //        command.Parameters["@ClinicZip"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicPhoneNumber", SqlDbType.VarChar).Value = ClinicPhoneNumber;
        //        command.Parameters["@ClinicPhoneNumber"].Direction = ParameterDirection.Input;

        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException InsertError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = InsertError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }

        //    }
        //}

        //public void AddVet(string VetName, string LicenseNumber, int VetClinicID, string ConnectionString)
        //{
        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "AddVet";

        //        command.Parameters.Add("@VetName", SqlDbType.VarChar).Value = VetName;
        //        command.Parameters["@VetName"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@LicenseNumber", SqlDbType.VarChar).Value = LicenseNumber;
        //        command.Parameters["@LicenseNumber"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@VetClinicID", SqlDbType.Int).Value = VetClinicID;
        //        command.Parameters["@VetClinicID"].Direction = ParameterDirection.Input;

        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException InsertError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = InsertError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }

        //    }
        //}

        //#endregion

        //#region "Update Methods"

        //public void UpdateVetClinic(int VetClinicID, string ClinicName, string ClinicAddress, string ClinicCity, string ClinicState, string ClinicZip, string ClinicPhoneNumber, string ConnectionString)
        //{
        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "UpdateVetClinic";

        //        command.Parameters.Add("@VetClinicID", SqlDbType.Int).Value = VetClinicID;
        //        command.Parameters["@VetClinicID"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicName", SqlDbType.VarChar).Value = ClinicName;
        //        command.Parameters["@ClinicName"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicAddress", SqlDbType.VarChar).Value = ClinicAddress;
        //        command.Parameters["@ClinicAddress"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicCity", SqlDbType.VarChar).Value = ClinicCity;
        //        command.Parameters["@ClinicCity"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicState", SqlDbType.VarChar).Value = ClinicState;
        //        command.Parameters["@ClinicState"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicZip", SqlDbType.VarChar).Value = ClinicZip;
        //        command.Parameters["@ClinicZip"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@ClinicPhoneNumber", SqlDbType.VarChar).Value = ClinicPhoneNumber;
        //        command.Parameters["@ClinicPhoneNumber"].Direction = ParameterDirection.Input;


        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException UpdateError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = UpdateError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }

        //    }
        //}

        //public void UpdateVet(int VetID, string VetName, string LicenseNumber, int VetClinicID, string ConnectionString)
        //{
        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "UpdateVet";

        //        command.Parameters.Add("@VetID", SqlDbType.Int).Value = VetID;
        //        command.Parameters["@VetID"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@VetName", SqlDbType.VarChar).Value = VetName;
        //        command.Parameters["@VetName"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@LicenseNumber", SqlDbType.VarChar).Value = LicenseNumber;
        //        command.Parameters["@LicenseNumber"].Direction = ParameterDirection.Input;
        //        command.Parameters.Add("@VetClinicID", SqlDbType.Int).Value = VetClinicID;
        //        command.Parameters["@VetClinicID"].Direction = ParameterDirection.Input;

        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException UpdateError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = UpdateError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }

        //    }
        //}

        //#endregion

        //#region "Delete Methods"

        //public void DeleteVetClinic(int VetClinicID, string ConnectionString)
        //{

        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "DeleteVetClinic";

        //        //Add parameter(s) to the command object. These must match the parameters in the sproc signature
        //        command.Parameters.Add("@VetClinicID", SqlDbType.Int).Value = VetClinicID;

        //        //Set parameter direction: input, input/output, or output (must match sproc signature)
        //        command.Parameters["@VetClinicID"].Direction = ParameterDirection.Input;

        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException DeleteError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = DeleteError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }
        //    }
        //}

        //public void DeleteVet(int VetID, string ConnectionString)
        //{

        //    // Create & open a SqlConnection, and dispose of it after we are done
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        // Create a command and prepare it for execution by the data tier
        //        SqlCommand command = new SqlCommand();

        //        // Associate the connection with the command. There could be more than one connection open.
        //        command.Connection = connection;

        //        // Set the command type: sproc, return an entire table, supply SQL string
        //        command.CommandType = CommandType.StoredProcedure;

        //        //In this case, the Command Text, meaning the command to be executed by the data tier
        //        //is the name of the sproc. We know this because the command type is storedprocedure
        //        //If the type were "Text" we would put the SQL expression here.
        //        command.CommandText = "DeleteVet";

        //        //Add parameter(s) to the command object. These must match the parameters in the sproc signature
        //        command.Parameters.Add("@VetID", SqlDbType.Int).Value = VetID;

        //        //Set parameter direction: input, input/output, or output (must match sproc signature)
        //        command.Parameters["@VetID"].Direction = ParameterDirection.Input;

        //        //This try catch block handles errors where the sproc (data tier) does not return a result
        //        try
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        catch (SqlException DeleteError)
        //        {
        //            //If the sproc didn't return a result, put the error message in dtJob
        //            pErrorMessage = DeleteError.Message.ToString();
        //            pTransactionSuccessful = false;
        //        }
        //    }
        //}
        //#endregion
    }
}