---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.SetStructuralSection(Autodesk.Revit.DB.Structure.StructuralSections.StructuralSection)
zh: 族类型、族符号
source: html/c3348673-0c95-eaf6-9d89-8cd8c81b48f6.htm
---
# Autodesk.Revit.DB.FamilySymbol.SetStructuralSection Method

**中文**: 族类型、族符号

Sets the structural section in element.

## Syntax (C#)
```csharp
public void SetStructuralSection(
	StructuralSection structuralSection
)
```

## Parameters
- **structuralSection** (`Autodesk.Revit.DB.Structure.StructuralSections.StructuralSection`) - Structural section with values that will be set.

## Remarks
Only beams, braces and structural columns can have a structural section.
 To check if the element can have structural section use the [!:Family.HasStructuralSection()] method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FamilySymbol cannot have a structural section.

