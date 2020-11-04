using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrimeLaundry.Models;
using Refit;
using static PrimeLaundry.Models.Login_Resp_Model;

namespace DoctorDiary.Services
{
    [Headers("Content-Type: application/json")]
    interface LaundryAPIInterface
    {
        /*[Get("/api/v1/products.json?brand={brand}")]
        Task<List<MakeUp>> GetMakeUps(string brand);*/

        //social media login API
        //[Post("/api/Doctor/SignUpUsingSocialMedia")]
        //Task<Login_Resp_Model> SignUpUsingSocialMedia([Body] LoginData csUser, [Header("Authorization")] string token);

        /* Login API */
        [Get("/api/Doctor/Get_User?username={username}&password={password}&app_version={version}&os={OS}")]
        Task<Login_Resp_Model> GetLogin(string username, string password, string version, string OS);

        /* GetAllDataByUserId API */
        //[Get("/api/Doctor/GetAllDataByUserId?userId={userId}")]
        //Task<GetLoginDataModel> GetAllDataByUserId(string userId, [Header("Authorization")] string token);

        ///* Change Password API */
        //[Get("/api/Doctor/Update_UserPassword?uid={userID}&newpasswd={password}")]
        //Task<ChangePasswordRespModel> GetChangePassword(string userID, string password, [Header("Authorization")] string token);

        ///* Forgot Password API */
        //[Get("/api/Doctor/Forgot_Password?Email={email}")]
        //Task<string> GetForgotPassword(string email, [Header("Authorization")] string token);

        ///* Precription List API*/
        //[Get("/api/Doctor/Get_Prescription?Treat_crno={t_no}")]
        //Task<PrescriptionList> GetPrecription(int t_no, [Header("Authorization")] string token);

        ///* Treatment List API*/
        //[Get("/api/Doctor/Get_Dashboard?User_Id={u_id}&DateFrom={fromDate}&DateTo={toDate}")]
        //Task<Treatment_List> GetTreatment(int u_id, string fromDate, string toDate, [Header("Authorization")] string token);

        ///* Get current app version  API*/
        //[Get("/api/Doctor/Get_Version")]
        //Task<LoginVersionResponse> Get_Version();

        //// api/Doctor/SendOtp? EmailId = { EmailId }&MobileNo={MobileNo }&OTP={OTP }
        //[Post("/api/Doctor/SendOtp")]
        //Task<SendOtpResponse> SendOtp([Query] string EmailId, string MobileNo, string OTP);

        //// SendPrescriptoinSMS
        //[Post("/api/Doctor/SendPrescriptoinSMS")]
        //Task<SMSResponseModel> SendPrescriptoinSMS(string number, [Body] List<PrescriptionMasterList> prescriptions, [Header("Authorization")] string token);

        ////  SendPrescriptoinSMS
        //[Post("/api/Doctor/SendPrescriptoinSMS")]
        //Task<SMSResponseModel> SendPrescriptoinSMS([Body] SendAppointmentPrescriptoinSMS_ReqModel sMSRequest, [Header("Authorization")] string token);

        ///* Get_SymptomsDiseaseByUserId */
        //[Get("/api/Doctor/GetAllSymptomsDisease?userId={userId}")]
        //Task<SymptomsDiseaseModel> Get_SymptomsDisease(string userId, [Header("Authorization")] string token);

        ///* Send_ReportMail */
        //[Get("/api/Doctor/Send_ReportMail?subject={subject}&body={body}&fromEmail={fromEmail}")]
        //Task<SubmitReportModel> Send_ReportMail(string subject, string body, string fromEmail, [Header("Authorization")] string token);

        ///* GetDoctorShift */
        //[Get("/api/Doctor/GetDoctorShift?DoctorId={DoctorId}&Date={Date}")]
        //Task<DoctorShiftModel> GetDoctorShift(string DoctorId, string Date, [Header("Authorization")] string token);

        ///*Get_Appointments*/
        //[Get("/api/AppointmentAPI/Get_Appointments?DoctorId={DoctorId}&fromDate={fromDate}&toDate={toDate}")]
        //Task<AppointmentModel> Get_Appointments(string DoctorId, string fromDate, string toDate, [Header("Authorization")] string token);

        ///*UpdateStatus_Appointment*//*
        //[Post("/api/AppointmentAPI/UpdateStatus_Appointment?id={AppId}&status={status}&msg={msg}")]
        //Task<UpdateStatus_Appointment_Model> UpdateStatus_Appointment(string AppId, string status, string msg, [Header("Authorization")] string token);*/

        ///*Update_Doctor*/
        //[Post("/api/Doctor/Update_Doctor")]
        //Task <UpdateProfileRespModel> Update_Doctor(DoctorData doctorShiftModel, [Header("Authorization")] string token);


        ///*Update_Appointment*/
        //[Post("/api/AppointmentAPI/Update_Appointment")]
        //Task<UpdateAppointmentRespModel> Update_Appointment(PatientAppoinmentDetails appoinmentDetails, [Header("Authorization")] string token);
    }
}
