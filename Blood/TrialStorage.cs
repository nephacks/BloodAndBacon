using System;
using System.IO;
using System.IO.IsolatedStorage;

#nullable disable
namespace Blood
{
  public class TrialStorage
  {
    public string status = "";

    public TrialData LoadTrial()
    {
      using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, (Type) null, (Type) null))
      {
        this.status = "";
        TrialData trialData = new TrialData();
        trialData.fileExists = false;
        string path = "savetrial";
        if (!store.FileExists(path))
        {
          this.status = "";
          return trialData;
        }
        try
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) store.OpenFile(path, FileMode.Open)))
          {
            trialData.fileExists = binaryReader.ReadBoolean();
            trialData.attempt = binaryReader.ReadInt32();
            binaryReader.Close();
          }
        }
        catch
        {
          this.status = "Error Loading Trial\n";
        }
        return trialData;
      }
    }

    public void SaveTrial(TrialData sg)
    {
      this.status = "";
      using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, (Type) null, (Type) null))
      {
        string path = "savetrial";
        try
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) store.OpenFile(path, FileMode.Create)))
          {
            binaryWriter.Write(true);
            binaryWriter.Write(sg.attempt);
            binaryWriter.Close();
          }
        }
        catch
        {
          this.status = "Error Saving Trial\n";
        }
      }
    }
  }
}
