---
kind: method
id: M:Autodesk.Revit.DB.TextElement.GetMaximumAllowedWidth(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/7d1c6767-3555-0321-f14a-a4e829c7171d.htm
---
# Autodesk.Revit.DB.TextElement.GetMaximumAllowedWidth Method

Returns the maximum width the text element can be created with.

## Syntax (C#)
```csharp
public static double GetMaximumAllowedWidth(
	Document cdda,
	ElementId typeId
)
```

## Parameters
- **cdda** (`Autodesk.Revit.DB.Document`) - A document containing the new text element's type
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Id of the text type

## Returns
The maximum allowed width in paper space [ft].

## Remarks
Note that it is not necessarily a constant; it can be affected
 by properties of the text type, such as the width factor.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

