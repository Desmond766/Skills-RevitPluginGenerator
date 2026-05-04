---
kind: property
id: P:Autodesk.Revit.DB.Element.DesignOption
zh: 构件、图元、元素
source: html/5c20fe58-e301-6ddb-3438-666db5c586ee.htm
---
# Autodesk.Revit.DB.Element.DesignOption Property

**中文**: 构件、图元、元素

Returns the design option to which the element belongs.

## Syntax (C#)
```csharp
public DesignOption DesignOption { get; }
```

## Remarks
If the element is not in a design option, i.e. in the main model, then this property will
return Nothing nullptr a null reference ( Nothing in Visual Basic) .

