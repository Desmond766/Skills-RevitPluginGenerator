---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.SetValue(System.Collections.Generic.IList{Autodesk.Revit.DB.Visual.AssetProperty})
source: html/70636c87-abd8-0a07-c5e6-a7193a5305ed.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.SetValue Method

Sets collection of properties stored in this property list.

## Syntax (C#)
```csharp
public void SetValue(
	IList<AssetProperty> value
)
```

## Parameters
- **value** (`System.Collections.Generic.IList < AssetProperty >`) - An array of properties.

## Remarks
All the properties in the list are of the same AssetPropertyType.
 The AssetPropertyType can only be Integer, Double4, Float or Double, Enumeration.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input value is invalid for this AssetPropertyList property.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable.

