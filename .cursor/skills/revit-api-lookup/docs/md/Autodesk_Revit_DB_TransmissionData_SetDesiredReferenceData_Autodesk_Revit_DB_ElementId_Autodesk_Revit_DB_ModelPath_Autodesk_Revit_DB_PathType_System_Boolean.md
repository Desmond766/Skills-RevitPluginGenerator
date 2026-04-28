---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.SetDesiredReferenceData(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.PathType,System.Boolean)
source: html/25aa4266-9f7f-0e5c-6cad-2e14eb00f984.htm
---
# Autodesk.Revit.DB.TransmissionData.SetDesiredReferenceData Method

Sets the ExternalFileReference information which
 Revit should use the next time it opens the document
 which this TransmissionData belongs to.

## Syntax (C#)
```csharp
public void SetDesiredReferenceData(
	ElementId elemId,
	ModelPath path,
	PathType pathType,
	bool shouldLoad
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The id of the element associated with this reference.
- **path** (`Autodesk.Revit.DB.ModelPath`) - A ModelPath indicating the location to load the external
 file reference from.
- **pathType** (`Autodesk.Revit.DB.PathType`) - A PathType value indicating what type of path the ModelPath is.
- **shouldLoad** (`System.Boolean`) - True if the external file should be loaded the next time Revit
 opens the document. False if it should be unloaded.

## Remarks
There must already be a reference associated with
 the given id for this function to be valid. New
 references cannot be created in a closed file.
 See the documentation for a particular reference
 type to see its creation API.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elemId does not correspond to an ExternalFileReference
 contained in this TransmissionData.
 -or-
 These inputs will not produce a valid ExternalFileReference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

