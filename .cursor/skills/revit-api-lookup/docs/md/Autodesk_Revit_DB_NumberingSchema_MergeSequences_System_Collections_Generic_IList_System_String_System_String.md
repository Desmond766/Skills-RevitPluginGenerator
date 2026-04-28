---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.MergeSequences(System.Collections.Generic.IList{System.String},System.String)
source: html/45697dc7-68b2-4fa8-1bea-8f65983f23a0.htm
---
# Autodesk.Revit.DB.NumberingSchema.MergeSequences Method

Merges all elements from given numbering sequences to a new sequence.

## Syntax (C#)
```csharp
public void MergeSequences(
	IList<string> sourcePartitions,
	string newPartition
)
```

## Parameters
- **sourcePartitions** (`System.Collections.Generic.IList < String >`) - A collection of partition names identifying the sequences to be merged together.
 There must be at least two names in the list. All the sequences must exist already.
- **newPartition** (`System.String`) - Name of a new partition into which the source sequences will be merged.
 Leading and trailing white space is ignored in the given string and will be removed automatically.

## Remarks
Upon a successful merge, all elements in the new merged sequence
 will be renumbered in order of the element creation. There will be no gaps. There must not be a sequence for the target partition in the schema yet,
 otherwise an exception will be thrown. This operation modifies the Partition parameter of all elements
 in the sequences that are being merged. Therefore, all its elements
 must be accessible for editing, otherwise this operation will fail.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sourcePartitions list must contain at least two names.
 -or-
 Either one or more sequences in the sourcePartitions list does
 not exist in the schema, or the list contains duplicated names.
 -or-
 The sequence newPartition does already exist in the schema.
 -or-
 the given newPartition cannot be used as a valid name of a numbering partition
 because it contains characters that are considered invalid, such as
 non-printable characters or those that cannot be used in a file's name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.
 -or-
 Thrown if there is an element that cannot have new value of the NUMBER_PARTITION_PARAM
 parameter assigned. It may be an indication that the element is not free to be edited at present.

