---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.IsValidColumn(Autodesk.Revit.DB.FamilyInstance)
source: html/7e0f712b-2b3a-6f2e-dd87-1e32383cc0e0.htm
---
# Autodesk.Revit.DB.ColumnAttachment.IsValidColumn Method

Says whether a FamilyInstance supports column attachments.

## Syntax (C#)
```csharp
public static bool IsValidColumn(
	FamilyInstance familyInstance
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - A column.

## Remarks
In-place columns do not support attachments.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

