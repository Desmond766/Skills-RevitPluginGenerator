---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetTopLevelLink(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ModelPath)
source: html/7a44c5d9-4cad-1f6b-f78e-b5fef077aa8c.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetTopLevelLink Method

Returns the ElementId of the (top-level) linked model with the given path.

## Syntax (C#)
```csharp
public static ElementId GetTopLevelLink(
	Document document,
	ModelPath path
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to look for the linked model in.
- **path** (`Autodesk.Revit.DB.ModelPath`) - A path indicating which linked model to return.

## Returns
The id of the link with the given path, or InvalidElementId if
 there is no top-level link at that path.

## Remarks
This function will not return nested links.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

