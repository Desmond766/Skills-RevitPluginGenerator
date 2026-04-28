---
kind: method
id: M:Autodesk.Revit.DB.Segment.AddSize(Autodesk.Revit.DB.MEPSize)
source: html/af752d1f-25fc-4226-cf08-16934c270522.htm
---
# Autodesk.Revit.DB.Segment.AddSize Method

Adds a new MEPSize to the segment.

## Syntax (C#)
```csharp
public void AddSize(
	MEPSize size
)
```

## Parameters
- **size** (`Autodesk.Revit.DB.MEPSize`) - The new MEPSize to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is already a same size in the settings.
 -or-
 The size already exists in the segment.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

