---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellStyle(Autodesk.Revit.DB.TableCellStyle)
source: html/9bb8b594-60f3-6a65-5fc3-2445242ed300.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellStyle Method

Sets a section's style

## Syntax (C#)
```csharp
public void SetCellStyle(
	TableCellStyle Style
)
```

## Parameters
- **Style** (`Autodesk.Revit.DB.TableCellStyle`)

## Remarks
For standard schedule, must set the TableCellStyleOverrideOptions in the TableCellStyle to override this section.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

