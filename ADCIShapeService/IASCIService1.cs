using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ADCIShapeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="DrawASCIShapes")]
    public interface IASCIService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<string> GenerateSquare(int height, string TxtToDisplay, int TxtRowNum);

        [OperationContract]
        List<string> GenerateRectangle(int height, string TxtToDisplay, int TxtRowNum);

        [OperationContract]
        List<string> GenerateTriangle(int height, string TxtToDisplay, int TxtRowNum);

        [OperationContract]
        List<string> GenerateDiamond1(int height, string TxtToDisplay, int TxtRowNum);

        [OperationContract]
        List<string> GenerateDiamond2(int height, string TxtToDisplay, int TxtRowNum);

        [OperationContract]
        void SaveHistoryToFile(string Shape, int height, string TxtToDisplay, int TxtRowNum);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
