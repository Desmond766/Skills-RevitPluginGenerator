---
kind: property
id: P:Autodesk.Revit.DB.Structure.AnalyticalMember.SectionTypeId
source: html/5e8a8f22-82e6-1a60-2ca1-bea0ea6a86a1.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SectionTypeId Property

The id of the type from the structural Family assigned to the Analytical Member.

## Syntax (C#)
```csharp
public ElementId SectionTypeId { get; set; }
```

## Remarks
The type must be of category "Structural Framing"
 (OST_StructuralFraming) or "Structural Columns" (OST_StructuralColumns)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: sectionTypeId is the id of some element that is not a
 FamilySymbol or is not of the category "Structural Framing"
 (OST_StructuralFraming) or "Structural Columns" (OST_StructuralColumns)
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

