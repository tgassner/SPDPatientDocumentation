using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Data;

namespace SPD.DAL {
    /// <summary>
    /// Factory Class for the Classer thar represent The Database Tables
    /// </summary>
  public class Database {
      /// <summary>
      /// Factory that creates a patient object.
      /// </summary>
      /// <returns></returns>
    public static IPatient CreatePatient() {
        return new Patient();
    }

    /// <summary>
    /// Factory that creates a patient visit.
    /// </summary>
    /// <returns></returns>
    public static IVisit CreateVisit() {
        return new Visit();
    }

    /// <summary>
    /// Factory that creates a patient operation.
    /// </summary>
    /// <returns></returns>
    public static IOperation CreateOperation() {
        return new Operation();
    }

    /// <summary>
    /// Factory that creates a patient photo.
    /// </summary>
    /// <returns></returns>
    public static IPhoto CreatePhoto() {
        return new Photo();
    }

    /// <summary>
    /// Factory that creates a Next Action.
    /// </summary>
    /// <returns></returns>
    public static INextAction CreateNextAction() {
        return new NextAction();
    }

    /// <summary>
    /// Creates the diagnose group.
    /// </summary>
    /// <returns></returns>
    public static IDiagnoseGroup CreateDiagnoseGroup() {
        return new DiagnoseGroup();
    }
}
}
