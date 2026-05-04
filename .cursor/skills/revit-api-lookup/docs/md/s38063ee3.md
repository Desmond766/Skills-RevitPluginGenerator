---
kind: method
id: M:Autodesk.Revit.DB.NumberSystem.SetReferencePick(Autodesk.Revit.DB.Reference)
source: html/d063f592-a128-bb1f-f0a3-9bb019ed8aef.htm
---
# Autodesk.Revit.DB.NumberSystem.SetReferencePick Method

Sets the reference pick.

## Syntax (C#)
```csharp
public void SetReferencePick(
	Reference referencePick
)
```

## Parameters
- **referencePick** (`Autodesk.Revit.DB.Reference`) - The pick to set.

## Remarks
It is suggested to get the new reference via GetNumberSystemReference() from the host element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The referencePick is not a valid reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

