---
kind: method
id: M:Autodesk.Revit.DB.ExportDWGSettings.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.DWGExportOptions)
zh: 创建、新建、生成、建立、新增
source: html/b693114f-746b-fb8e-e557-2ddedd6e5684.htm
---
# Autodesk.Revit.DB.ExportDWGSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a DWG export settings with default values.

## Syntax (C#)
```csharp
public static ExportDWGSettings Create(
	Document document,
	string name,
	DWGExportOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where created settings is saved.
- **name** (`System.String`) - The name specified to this settings.
- **options** (`Autodesk.Revit.DB.DWGExportOptions`) - Initialize settings by using values in DWGExportOptions.

## Returns
The new DWG export settings instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ExistOrEmpty
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

