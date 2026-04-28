---
kind: type
id: T:Autodesk.Revit.DB.NumberingSchema
source: html/8f2b22da-5963-301f-44d8-10c68828c436.htm
---
# Autodesk.Revit.DB.NumberingSchema

A class to support assigning numbers to elements of a particular kind for the purpose of tagging and scheduling them.

## Syntax (C#)
```csharp
public class NumberingSchema : Element
```

## Remarks
Each NumberingSchema controls numbering of elements of one particular kind, typically of the same category such
 as Rebar or Fabric Reinforcement. Instances of NumberingSchema are also elements and there is always only one of
 each type in every Revit document. Available types of all built-in numbering schemas are enumerated in
 NumberingSchemaTypes class. At present, schema elements cannot be manually
 added, deleted, or copied. Attempts to do so will result in a failure warning and/or exceptions thrown. Elements (e.g. Rebar) belonging to a particular schema (e.g. NumberingSchemaTypes.StructuralNumberingSchemas.Rebar)
 are organized and numbered in sequences. A sequence is a collection of elements that share the same numbering partition
 as defined by their respective values of the Partition parameter (NUMBER_PARTITION_PARAM). For a numbering sequence
 to exist it must contain at least one element. In other words, a sequence is established once there is at least
 one element of which the partition parameter has a value that differs from other elements (in the same numbering schema).
 If the last element is removed (deleted or moved to a different sequence) the then empty sequence ceases to exist. Elements get assigned to sequences either upon their creation (based on the then current numbering partition value),
 or by explicitly modifying the Partition parameter of an element, or by using the AssignElementsToSequence method.
 It is highly recommended using that method over explicitly changing the Partition parameter, because the methods applies changes
 to sequences and element numbers immediately, while changed parameters get into effect only after the current transaction is closed. In addition to directly or indirectly changing the Partition parameter of elements, numbering sequences can be
 reorganized by using methods of the NumberingSchema class. The MoveSequence method moves
 all elements of an existing sequence to a new sequence that does not exist yet in the schema, thus effectively renaming
 the Partition parameter on all the affected elements. The AppendSequence method removes
 all elements from one sequence and appends them to elements of another existing sequence while applying the matching policy.
 The method MergeSequences takes elements of all specified sequences and moves them all into a newly created sequence.
 All the merged elements will be renumbered and matched as needed based on the matching algorithm. Elements in different sequences are numbered independently, meaning that there may be elements with the same
 number in two sequences even though the elements are different. Likewise, there may be perfectly identical
 elements in two or more sequences bearing different numbers. However, within each one numbering sequence any
 two identical elements will always have the same number, while different elements will never have the same
 number within a numbering sequence. Revit refers to this rule as the matching policy. Enumerable elements are always numbered automatically upon their creation. Each new element will get an
 incrementally higher number. However, thanks to the matching policy, new elements that match existing elements
 within the same sequence will get the same number assigned. Elements will keep their assigned numbers as long
 as it is possible. This means, for example, that if some previously created elements (e.g. Rebar) get deleted,
 all remaining elements (within the same numbering sequence) will keep their numbers, which may result in gaps in
 the respective numbering sequence. Gaps can be removed by invoking RemoveGaps for sequences
 in which gaps are not desired. Numbers are stored as values of a numbering parameter on each numbered element. The Id of the parameter is obtained
 by querying the NumberingParameterId property. The value of the number can be obtained by querying the
 parameter for the respective numbered element. The value is read-only and thus cannot be set; it is always computed based
 on relations of elements across numbering partitions and the matching policy within the numbering sequence of each element. Even though numbers are always assigned automatically to all elements of a schema, the method
 ChangeNumber gives the programmer a way to explicitly overwrite a specific number as long
 as the new number is unique in the numbering sequence. The caller specifies a number to be changed and a new value that is
 to be applied, providing the value does not exist yet in the same numbering sequence. Although this operation may seem rather
 limited, it provides the programmer with freedom to change practically any number even if it may be achieved in multiple steps.

