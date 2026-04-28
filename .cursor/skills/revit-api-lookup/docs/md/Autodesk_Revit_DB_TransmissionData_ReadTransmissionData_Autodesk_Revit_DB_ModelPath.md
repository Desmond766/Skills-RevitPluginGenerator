---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.ReadTransmissionData(Autodesk.Revit.DB.ModelPath)
source: html/5158f72e-6f8d-fa45-c7f6-349a86067b8e.htm
---
# Autodesk.Revit.DB.TransmissionData.ReadTransmissionData Method

Reads the TransmissionData associated with the
 file at the given location.

## Syntax (C#)
```csharp
public static TransmissionData ReadTransmissionData(
	ModelPath path
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - A ModelPath indicating the file Revit should read
 the TransmissionData of.
 If this ModelPath is a file path, it must be an absolute path.

## Returns
The TransmissionData containing external file
 information for the file at the given location.

## Remarks
The TransmissionData returned by this function contains
 data about all ExternalFileReferences in the document.
 ExternalResourceReferences to extenal servers will not
 be returned by this function. TransmissionData contains
 information about local or Revit Server references only.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model are locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - There is not a valid Revit file at path's location
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.

