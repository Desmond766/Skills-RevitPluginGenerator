---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeParameters.GetExternalDefinitionForElementId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.DefinitionFile)
source: html/80be14d9-abda-9538-56ac-f198550d11ae.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeParameters.GetExternalDefinitionForElementId Method

Seach a DefinitionFile for the ExternalDefinition corresponding to a parameter
in a document.

## Syntax (C#)
```csharp
public static ExternalDefinition GetExternalDefinitionForElementId(
	Document doc,
	ElementId paramId,
	DefinitionFile definitionFile
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of a shared parameter in the document.
- **definitionFile** (`Autodesk.Revit.DB.DefinitionFile`) - A database of shared parameters.

## Returns
The external parameter corresponding to the parameter's ElementId,
 or null if the Id does not correspond to an external parameter,
 or the parameter is not in the definition file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was Nothing nullptr a null reference ( Nothing in Visual Basic) .

