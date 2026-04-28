---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.WriteTransmissionData(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.TransmissionData)
source: html/96561c21-134c-9744-45de-8c3f772f0676.htm
---
# Autodesk.Revit.DB.TransmissionData.WriteTransmissionData Method

Writes the given TransmissionData into the Revit file at the
 given location.

## Syntax (C#)
```csharp
public static void WriteTransmissionData(
	ModelPath path,
	TransmissionData data
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - A ModelPath indicating the file Revit should write
 the TransmissionData of.
 This ModelPath must be a file path and an absolute path.
- **data** (`Autodesk.Revit.DB.TransmissionData`) - The TransmissionData to be written into the document.
 Note that Revit will not check that the ElementIds in
 the TransmissionData correspond to real Elements.

## Remarks
This function will overwrite the existing TransmissionData
 in the file. This function will not support models on Revit Server. References
 may be to Revit Server, but the host model must be local. This function must be called on a closed document. This function cannot be used to convert a reference from
 a local file to an external server.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - There is not a valid Revit file at path's location
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Operation is not valid for Revit Server models.
 -or-
 This function cannot be called on an opened document.

