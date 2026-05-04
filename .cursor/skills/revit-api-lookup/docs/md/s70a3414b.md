---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.Export(System.String,System.String,Autodesk.Revit.DB.ViewScheduleExportOptions)
zh: 导出、输出
source: html/8ba18e73-6daf-81b6-d15b-e4aa90bc8c22.htm
---
# Autodesk.Revit.DB.ViewSchedule.Export Method

**中文**: 导出、输出

Exports the schedule data to a text file.

## Syntax (C#)
```csharp
public void Export(
	string folder,
	string name,
	ViewScheduleExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Path to the location where the file will be saved.
- **name** (`System.String`) - Name of file.
- **options** (`Autodesk.Revit.DB.ViewScheduleExportOptions`) - Options that relate to schedule export.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The path indicated could not be accessed.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.

