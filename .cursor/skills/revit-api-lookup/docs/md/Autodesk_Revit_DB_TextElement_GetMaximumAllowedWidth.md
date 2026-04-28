---
kind: method
id: M:Autodesk.Revit.DB.TextElement.GetMaximumAllowedWidth
source: html/bab10434-83a8-5263-765a-45080f882559.htm
---
# Autodesk.Revit.DB.TextElement.GetMaximumAllowedWidth Method

Returns the maximum width the text element can be assigned.

## Syntax (C#)
```csharp
public double GetMaximumAllowedWidth()
```

## Returns
The maximum allowed width in paper space [ft].

## Remarks
Note that it is not necessarily a constant; it can be affected
 by properties of the text and its type, such as the width factor.

