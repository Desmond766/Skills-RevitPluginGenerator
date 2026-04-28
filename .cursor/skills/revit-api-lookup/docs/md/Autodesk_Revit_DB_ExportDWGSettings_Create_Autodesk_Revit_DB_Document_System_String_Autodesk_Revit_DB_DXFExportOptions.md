---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.DXFExportOptions)
zh: 创建、新建、生成、建立、新增
source: html/b9476032-59cf-f4a1-16ed-8c6bb7ed1ea3.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a DWG export settings with default values.

## Syntax (C#)
```csharp
public static ExportDWGSettings Create(
	Document document,
	string name,
	DXFExportOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where created settings is saved.
- **name** (`System.String`) - The name specified to this settings.
- **options** (`Autodesk.Revit.DB.DXFExportOptions`) - Initialize settings by using values in DXFExportOptions.

## Returns
The new DWG export settings instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ExistOrEmpty
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

