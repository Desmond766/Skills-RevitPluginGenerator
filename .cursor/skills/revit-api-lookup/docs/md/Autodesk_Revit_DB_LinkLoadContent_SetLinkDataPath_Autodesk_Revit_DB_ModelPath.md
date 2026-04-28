---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadContent.SetLinkDataPath(Autodesk.Revit.DB.ModelPath)
source: html/64635337-db25-6032-1899-4d4a0de212c1.htm
---
# Autodesk.Revit.DB.LinkLoadContent.SetLinkDataPath Method

Sets the Link data path owned by this LinkLoadContent object.

## Syntax (C#)
```csharp
public void SetLinkDataPath(
	ModelPath linkPath
)
```

## Parameters
- **linkPath** (`Autodesk.Revit.DB.ModelPath`) - The Links data path set for this LinkLoadContent object.

## Remarks
This path must be a location accessible to Revit. Revit will
 attempt to load the link from this location.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

