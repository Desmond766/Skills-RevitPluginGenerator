---
kind: method
id: M:Autodesk.Revit.DB.AppearanceAssetElement.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Visual.Asset)
zh: 创建、新建、生成、建立、新增
source: html/f1daea30-3585-3332-adb1-dfe30d8a8180.htm
---
# Autodesk.Revit.DB.AppearanceAssetElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new AppearanceAssetElement from an existing rendering asset.

## Syntax (C#)
```csharp
public static AppearanceAssetElement Create(
	Document document,
	string name,
	Asset asset
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the AppearanceAssetElement.
- **name** (`System.String`) - The name of the AppearanceAssetElement.
- **asset** (`Autodesk.Revit.DB.Visual.Asset`) - The rendering asset of the element.

## Returns
The new AppearanceAssetElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as an appearance asset name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

