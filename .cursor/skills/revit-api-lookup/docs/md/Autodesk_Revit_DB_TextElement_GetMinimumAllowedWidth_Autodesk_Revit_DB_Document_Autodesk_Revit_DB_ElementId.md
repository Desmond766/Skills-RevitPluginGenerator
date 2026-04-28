---
kind: method
id: M:Autodesk.Revit.DB.TextElement.GetMinimumAllowedWidth(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/25772d7a-57ad-7638-3b6f-3426d4c64237.htm
---
# Autodesk.Revit.DB.TextElement.GetMinimumAllowedWidth Method

Returns the minimum width a text element can be created with.

## Syntax (C#)
```csharp
public static double GetMinimumAllowedWidth(
	Document cdda,
	ElementId typeId
)
```

## Parameters
- **cdda** (`Autodesk.Revit.DB.Document`) - A document containing the new text element's type
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Id of the text type

## Returns
The minimum allowed width in paper space [ft].

## Remarks
Note that it is not necessarily a constant; it can be affected
 by properties of the text type, such as the width factor.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

