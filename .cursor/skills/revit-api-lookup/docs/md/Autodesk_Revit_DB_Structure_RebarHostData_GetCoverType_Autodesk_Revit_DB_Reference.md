---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.GetCoverType(Autodesk.Revit.DB.Reference)
source: html/4d952f72-42b5-88f1-0788-7e64ff6589bb.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.GetCoverType Method

Gets the CoverType associated with a face of the element.

## Syntax (C#)
```csharp
public RebarCoverType GetCoverType(
	Reference face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Reference`)

## Returns
The cover associated with the face, if it is an exposed face.
 If the face is concealed, returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

