using System;
using Server;

namespace Server.Items
{
	public class LeftLeg : Item, ICarvable
    {
        #region ICarvable Members
        public void Carve(Mobile from, Item item)
        {
            from.AddToBackpack(new HumanJerky(m_Owner));
            Delete();
        }
        #endregion

		private Mobile m_Owner;

		[Constructable]
		public LeftLeg() : this( null )
		{
		}

		[Constructable]
		public LeftLeg( Mobile owner ) : base( 0x1DA3 )
		{
			m_Owner = owner;
			LastMoved = (DateTime.Now - Item.DefaultDecayTime) + TimeSpan.FromMinutes( 7.5 );
		}

		public LeftLeg( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
			writer.Write( m_Owner );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			if ( version == 1 )
				m_Owner = reader.ReadMobile();
		}
	}
}
