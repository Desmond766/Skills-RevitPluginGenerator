---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/e54ac7dc-0b2c-a1ae-a5d8-5bd794d2cb8d.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a DWG export settings with default values.

## Syntax (C#)
```csharp
public static ExportDWGSettings Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where created settings is saved.
- **name** (`System.String`) - The name specified to this settings.

## Returns
The new DWG export settings instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ExistOrEmpty
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

