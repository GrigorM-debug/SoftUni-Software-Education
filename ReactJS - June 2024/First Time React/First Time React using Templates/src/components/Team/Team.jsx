import TeamMember from "./TeamMember";

function Team() {
    return (
      <section
          className="barista-section section-padding section-bg"
          id="barista-team"
      >
          <div className="container">
            <div className="row justify-content-center">
              <div className="col-lg-12 col-12 text-center mb-4 pb-lg-2">
                <em className="text-white">Creative Baristas</em>
                <h2 className="text-white">Meet People</h2>
              </div>
              <TeamMember name="Steve" role="Boss" description="your favourite coffee daily lives tempor." imageUrl="images/team/portrait-elegant-old-man-wearing-suit.jpg"></TeamMember>
              <TeamMember name="Sandra" role="Manager" description="your favourite coffee daily lives." imageUrl="images/team/cute-korean-barista-girl-pouring-coffee-prepare-filter-batch-brew-pour-working-cafe.jpg"></TeamMember>
              <TeamMember name="Jackson" role="Senior" description="your favourite coffee daily lives." imageUrl="images/team/small-business-owner-drinking-coffee.jpg"></TeamMember>
              <TeamMember name="Michelle" role="Barista" description="your favourite coffee daily lives." imageUrl="images/team/smiley-business-woman-working-cashier.jpg"></TeamMember>
            </div>
          </div>
        </section>
    );
}

export default Team;