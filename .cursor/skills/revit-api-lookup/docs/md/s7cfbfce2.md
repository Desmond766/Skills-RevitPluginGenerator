---
kind: method
id: M:Autodesk.Revit.DB.TextElement.GetMinimumAllowedWidth
source: html/d074bc27-1e5a-7be1-359b-83592dad59dd.htm
---
# Autodesk.Revit.DB.TextElement.GetMinimumAllowedWidth Method

Returns the minimum width the text element can be assigned.

## Syntax (C#)
```csharp
public double GetMinimumAllowedWidth()
```

## Returns
The minimum allowed width in paper space [ft].

## Remarks
Note that it is not necessarily a constant; it can be affected
 by properties of the text and its type, such as the width factor.

