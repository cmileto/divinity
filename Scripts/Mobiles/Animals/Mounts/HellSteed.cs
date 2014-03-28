using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a hellsteed corpse" )]
	public class HellSteed : BaseMount
	{
		[Constructable] 
		public HellSteed() : this( "a hellsteed" )
		{
		}

		[Constructable]
		public HellSteed( string name ) : base( name, 793, 0x3EBB, AIType.AI_Animal, FightMode.Aggressor, 12, 1, 0.5, 0.75 )
		{
			SetStr( 201, 210 );
			SetDex( 101, 110 );
			SetInt( 101, 115 );

			SetHits( 201, 220 );

			SetDamage( 20, 24 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 90 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.MagicResist, 90.1, 110.0 );
			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.Wrestling, 90.1, 110.0 );

			Fame = 0;
			Karma = 0;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		// TODO: "This creature can breath chaos."

		public HellSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}