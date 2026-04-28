---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.GetAllStructuralConnectionApprovalTypes(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId}@)
source: html/17a6b10f-a08b-0dab-8356-546f546146e7.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.GetAllStructuralConnectionApprovalTypes Method

Collects the ids of all StructuralConnectionApprovalTypes in the document.

## Syntax (C#)
```csharp
public static void GetAllStructuralConnectionApprovalTypes(
	Document cda,
	out ICollection<ElementId> ids
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`)
- **ids** (`System.Collections.Generic.ICollection < ElementId > %`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

