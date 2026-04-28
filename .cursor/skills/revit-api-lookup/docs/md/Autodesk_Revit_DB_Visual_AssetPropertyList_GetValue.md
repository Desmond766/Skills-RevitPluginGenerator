---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetPropertyList.GetValue
source: html/4a87c399-54e2-5282-3a82-6f776481a3c7.htm
---
# Autodesk.Revit.DB.Visual.AssetPropertyList.GetValue Method

Gets a collection of properties stored in this property list. These properties are copied.

## Syntax (C#)
```csharp
public IList<AssetProperty> GetValue()
```

## Returns
Returns a copy of all the properties in this AssetPropertyList.

## Remarks
All the properties in the list are of the same AssetPropertyType.
 The AssetPropertyType can only be Integer, Double4, Float or Double, Enumeration.

