---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperties.FindByName(System.String)
source: html/ff64717a-fa49-d828-7daa-941986971a61.htm
---
# Autodesk.Revit.DB.Visual.AssetProperties.FindByName Method

Gets the property with the given name.

## Syntax (C#)
```csharp
public AssetProperty FindByName(
	string name
)
```

## Parameters
- **name** (`System.String`) - Name of the property.

## Returns
The property with the specified name.

## Remarks
FindByName will not visit the properties of any connected asset on any of the properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

