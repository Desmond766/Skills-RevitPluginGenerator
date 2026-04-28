---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.GetLastSavedReferenceData(Autodesk.Revit.DB.ElementId)
source: html/d5e70e0b-69f2-fcb4-0d91-4b184930b68d.htm
---
# Autodesk.Revit.DB.TransmissionData.GetLastSavedReferenceData Method

Gets the ExternalFileReference representing path
 and load status information concerning the most
 recent time this TransmissionData's document was opened.

## Syntax (C#)
```csharp
public ExternalFileReference GetLastSavedReferenceData(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the Element which the external file
 reference is a component of.

## Returns
An ExternalFileReference containing the previous
 path and load status information for an external file

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elemId does not correspond to an ExternalFileReference
 contained in this TransmissionData.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

