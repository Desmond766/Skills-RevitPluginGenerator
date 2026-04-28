---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.SetMapForFamilySymbolToFabricationPartType(System.Collections.Generic.IDictionary{Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId})
source: html/17be58d5-b0c9-2486-d2ab-90fd9f136133.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.SetMapForFamilySymbolToFabricationPartType Method

Set a map for the conversion of in line family symbols to similar fabrication part types.

## Syntax (C#)
```csharp
public DesignToFabricationMappingResult SetMapForFamilySymbolToFabricationPartType(
	IDictionary<ElementId, ElementId> typeMappings
)
```

## Parameters
- **typeMappings** (`System.Collections.Generic.IDictionary < ElementId , ElementId >`) - The map containing the family symbol element identifiers to the fabrication part type element identifiers to convert to.

## Returns
If the mapping is properly structured, DesignToFabricationMappingResult.Success is returned. Otherwise, consult the members of DesignToFabricationMappingResult to understand why this call failed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

