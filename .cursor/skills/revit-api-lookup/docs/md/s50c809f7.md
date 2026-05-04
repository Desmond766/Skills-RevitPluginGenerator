---
kind: method
id: M:Autodesk.Revit.DB.TransmissionData.GetDesiredReferenceData(Autodesk.Revit.DB.ElementId)
source: html/c27ef733-3960-9710-64e9-aa42b01657dc.htm
---
# Autodesk.Revit.DB.TransmissionData.GetDesiredReferenceData Method

Gets the ExternalFileReference representing path
 and load status information to be used the next time
 this TransmissionData's document is loaded.

## Syntax (C#)
```csharp
public ExternalFileReference GetDesiredReferenceData(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the Element which the external file
 reference is a component of.

## Returns
An ExternalFileReference containing the requested
 path and load status information for an external file

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elemId does not correspond to an ExternalFileReference
 contained in this TransmissionData.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

